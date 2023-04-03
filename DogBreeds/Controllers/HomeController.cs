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
     
    private  DogBreedsServices dogBreedsServices = new DogBreedsServices();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {

         List<DogBreed>doggos = new List<DogBreed>();    

         doggos = (List<DogBreed>)await dogBreedsServices.GetDoggosListAsync();
      

            return View(doggos);

        }

        public  IActionResult IndexXsd()
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
            if (file != null && file.Length > 0)
            {
                if (Path.GetExtension(file.FileName).ToLower() == ".xml")
                {
                    using (var reader = new StreamReader(file.OpenReadStream()))
                    {
                        var xml = reader.ReadToEnd();
                        ViewBag.Xml = xml;
                        return View("Result");
                    }
                }
                else
                {
                    ViewBag.Error = "The selected file is not an XML file.";
                }
            }
            else
            {
                ViewBag.Error = "Please select a file to upload.";
            }

            return View();
        }









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