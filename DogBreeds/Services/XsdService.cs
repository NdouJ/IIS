using System.Xml.Schema;
using System.Xml;
using DogBreeds.ViewModels;

namespace DogBreeds.Services
{
    public class XsdService
    {

    public SchemaValidationVM ValidateXMLFile(IFormFile file) {


            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var xml = reader.ReadToEnd();

                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.Add(null, "../DogBreeds/XSDDogBreeds.xsd");

                var readerSettings = new XmlReaderSettings();
                readerSettings.Schemas = schemaSet;

                readerSettings.ValidationType = ValidationType.Schema;

                var isValid = true;

                //pretplata na event koji će se podignuti u slučaju da se dogodi error pri validaciji
                readerSettings.ValidationEventHandler += (sender, args) =>
                {
                    Console.WriteLine($"Validation error: {args.Message}");
                    isValid = false;
                };

           
                using (var reader2 = XmlReader.Create(new StringReader(xml), readerSettings))
                {
                    while (reader2.Read())
                    {
                       
                    }
                }

                SchemaValidationVM r = new SchemaValidationVM(xml, isValid ? "valid" : "not valid");

                return r;
            }

        }
    }
}
