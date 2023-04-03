using DogBreeds.Models;
using DogBreeds.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml;

namespace DogBreeds.Controllers
{
    public class HomeController : Controller
    {

        private DogBreedsServices dogBreedsServices = new DogBreedsServices();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {

            List<DogBreed> doggos = new List<DogBreed>();

            doggos = (List<DogBreed>)await dogBreedsServices.GetDoggosListAsync();


            return View(doggos);

        }

        public IActionResult IndexXsd()
        {

            //static void Main(string[] args)
            //{
            //    var path = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
            //    XmlSchemaSet schema = new XmlSchemaSet();
            //    schema.Add("", path + "\\input.xsd");
            //    XmlReader rd = XmlReader.Create(path + "\\input.xml");
            //    XDocument doc = XDocument.Load(rd);
            //    doc.Validate(schema, ValidationEventHandler);
            //}
            //static void ValidationEventHandler(object sender, ValidationEventArgs e)
            //{
            //    XmlSeverityType type = XmlSeverityType.Warning;
            //    if (Enum.TryParse<XmlSeverityType>("Error", out type))
            //    {
            //        if (type == XmlSeverityType.Error) throw new Exception(e.Message);
            //    }
            //}



            return View();

        }
        [HttpPost]

        public IActionResult Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Error = "Please select a file to upload.";
                return View("Result", "nije uplodan file");
            }

            if (Path.GetExtension(file.FileName).ToLower() != ".xml")
            {
                ViewBag.Error = "The selected file is not an XML file.";
                return View("Result", "file nije .xml");
            }

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var xml = reader.ReadToEnd();
                ViewBag.Xml = xml;

                // Load the XSD schema from the file system
                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.Add(null, @"C:\\IIS\\DogBreeds\\XSDDogBreeds.xsd");

                // Create a reader settings object and assign the schema to it
                var readerSettings = new XmlReaderSettings();
                readerSettings.Schemas = schemaSet;

                // Set the validation type and event handler for validation errors
                readerSettings.ValidationType = ValidationType.Schema;
                var isValid = true;
                readerSettings.ValidationEventHandler += (sender, args) =>
                {
                    Console.WriteLine($"Validation error: {args.Message}");
                    isValid = false;
                };

                // Create an XML reader and validate the document against the schema
                using (var reader2 = XmlReader.Create(new StringReader(xml), readerSettings))
                {
                    while (reader2.Read())
                    {
                        // do nothing, just read the whole document
                    }
                }

                string r = isValid ? "d" : "n";
                return View("Result", r);
            }
        }



        //    public IActionResult Upload(IFormFile file)
        //    {

        //        string xmlString;
        //        if (file != null && file.Length > 0)
        //        {
        //            if (Path.GetExtension(file.FileName).ToLower() == ".xml")
        //            {
        //                using (var reader = new StreamReader(file.OpenReadStream()))
        //                {
        //                    var xml = reader.ReadToEnd();
        //                    ViewBag.Xml = xml;
        //                    xmlString = xml.ToString();

        //                    XmlSchemaSet schemaSet = new XmlSchemaSet();
        //                    schemaSet.Add(null, @"C:\\IIS\\DogBreeds\\XSDDogBreeds.xsd");

        //                    //   return View("Result", xmlString);


        //                    // Create a reader settings object and assign the schema to it
        //                    XmlReaderSettings readerSettings = new XmlReaderSettings();
        //                    readerSettings.Schemas = schemaSet;

        //                    // Set the validation type and event handler for validation errors
        //                    readerSettings.ValidationType = ValidationType.Schema;
        //                    readerSettings.ValidationEventHandler += (sender, args) =>
        //                    {
        //                        Console.WriteLine($"Validation error: {args.Message}");
        //                    };

        //                    // Create an XML reader and validate the document against the schema
        //                    using (XmlReader reader2 = XmlReader.Create(new StringReader(xml), readerSettings))
        //                    {
        //                        try
        //                        {
        //                            while (reader2.Read())
        //                            {
        //                                // do nothing, just read the whole document
        //                            }
        //                            return View("Result", "validan"); // if there are no errors, return true
        //                        }
        //                        catch (XmlException)
        //                        {
        //                            return View("Result", "nije validan"); ; // if there is an XmlException, return false
        //                        }
        //                        catch (XmlSchemaException)
        //                        {
        //                            return View("Result", " exc");// if there is an XmlSchemaException, return false
        //                        }
        //                    }


        //                }
        //            }
        //            else
        //            {
        //                ViewBag.Error = "The selected file is not an XML file.";
        //                return View("Result", " neka greska");
        //            }

        //            /*
        //                     else
        //    {
        //        ViewBag.Error = "The selected file is not an XML file.";
        //    }
        //}
        //else
        //{
        //    ViewBag.Error = "Please select a file to upload.";
        //}

        //             */

        //            /*
        //             using System.Xml;
        //using System.Xml.Schema;

        //public static bool ValidateXmlAgainstXsd(string xmlFilePath, string xsdFilePath)
        //{
        //    // Load the XML document to be validated
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(xmlFilePath);

        //    // Load the XSD schema from your project
        //    XmlSchemaSet schemaSet = new XmlSchemaSet();
        //    schemaSet.Add(null, xsdFilePath);

        //    // Create a reader settings object and assign the schema to it
        //    XmlReaderSettings readerSettings = new XmlReaderSettings();
        //    readerSettings.Schemas = schemaSet;

        //    // Set the validation type and event handler for validation errors
        //    readerSettings.ValidationType = ValidationType.Schema;
        //    readerSettings.ValidationEventHandler += (sender, args) =>
        //    {
        //        Console.WriteLine($"Validation error: {args.Message}");
        //    };

        //    // Create an XML reader and validate the document against the schema
        //    using (XmlReader reader = XmlReader.Create(xmlFilePath, readerSettings))
        //    {
        //        try
        //        {
        //            while (reader.Read())
        //            {
        //                // do nothing, just read the whole document
        //            }
        //            return true; // if there are no errors, return true
        //        }
        //        catch (XmlException)
        //        {
        //            return false; // if there is an XmlException, return false
        //        }
        //        catch (XmlSchemaException)
        //        {
        //            return false; // if there is an XmlSchemaException, return false
        //        }
        //    }
        //}

        //             */
        //            // return View();
        //        }

        //        else
        //        {
        //            return View("Result", "Ne znam kaj je puklo");
        //        }


        //    }




        public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
