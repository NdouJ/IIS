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


        public IActionResult Index()
        {


            return View();


        }



        private DogBreedsServices dogBreedsServices = new DogBreedsServices();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }




        public async Task<IActionResult> DogListAsync()
        {

            List<DogBreed> doggos = new List<DogBreed>();

            doggos = (List<DogBreed>)await dogBreedsServices.GetDoggosListAsync();


            return View(doggos);

        }



        public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Erroor()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
