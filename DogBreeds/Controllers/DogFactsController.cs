using DogBreeds.Models;
using DogBreeds.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Immutable;

namespace DogBreeds.Controllers
{
    public class DogFactsController : Controller
    {
        private readonly ILogger _logger;

        [HttpGet]
         public async Task<IActionResult>  Index()
        {
            DogFact fact;

            try
            {
                 fact = (DogFact)await DogFactsService.GetDogFact();
            }
            catch (Exception Ex)
            {
                _logger.LogInformation($"Error connecting to DogFacts api {Ex.Message}",
                DateTime.UtcNow.ToLongTimeString());
                return View("Error");
            }


            return View("Index", fact.Getfacts());


        }


       
        public async Task<IActionResult> IndexPost()
        {

            DogFact fact;

            try
            {
                fact = (DogFact)await DogFactsService.GetDogFact();
            }
            catch (Exception Ex)
            {
                _logger.LogInformation($"Error connecting to DogFacts api {Ex.Message}",
                  DateTime.UtcNow.ToLongTimeString());
                return View("Error");
               
            }


            return View("Index", fact.Getfacts());


        }
    }
}
