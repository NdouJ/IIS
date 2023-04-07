using DogBreeds.Models;
using DogBreeds.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogBreeds.Controllers
{
    public class XpathController : Controller
    {
        public IActionResult XPath()
        {


            return View();


        }
        [HttpPost]
        public IActionResult XPathResoult(string selecteddog)
        {


            return View("XPathResoult", XPathService.Search(selecteddog));


        }
    }
}
