using DogBreeds.Services;
using DogBreeds.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DogBreeds.Controllers
{
    public class XsdController : Controller
    {
        public IActionResult IndexXsd()
        {


            return View();


        }


        [HttpPost]
        public IActionResult Result(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Error = "Please select a file to upload.";
                return View("Result", new SchemaValidationVM("", "File not uploaded"));
            }

            if (Path.GetExtension(file.FileName).ToLower() != ".xml")
            {
                ViewBag.Error = "The selected file is not an XML file.";
                return View("Result", new SchemaValidationVM("", "This is not an XML file"));
            }

            XsdService service = new XsdService();



            return View("Result", service.ValidateXMLFile(file));
        }
    }
}
