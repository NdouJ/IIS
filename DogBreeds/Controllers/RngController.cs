using DogBreeds.Services;
using DogBreeds.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DogBreeds.Controllers
{
    public class RngController : Controller
    {
        public IActionResult RNG()
        {


            return View();


        }

        [HttpPost]

        public IActionResult UploadRng(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Error = "Please select a file to upload.";
               
                return View("ResultRNG", new SchemaValidationVM("", "file not uploaded"));
            }

            if (Path.GetExtension(file.FileName).ToLower() != ".xml")
            {
                ViewBag.Error = "The selected file is not an XML file.";
                return View("ResultRNG", new SchemaValidationVM("", "File is not .xml file"));
            }

            RNGService service = new RNGService();

            return View("ResultRNG", service.ValidateXMLFile(file));
        }
    }
}
