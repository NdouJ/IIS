using DogBreeds.Models;
using DogBreeds.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogBreeds.Controllers
{
    public class DhmzController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> WeatherAsync()
        {

            DHMZService dhMZService = new DHMZService();
            Task<IEnumerable<Grad>> taskCity = dhMZService.GetWeatherDataAsync();

            IEnumerable<Grad> cities = await taskCity;




            return View("Weather", cities);


        }

        [HttpPost]
        public async Task<IActionResult> SelectedGradAsync(string grads)
        {
            DHMZService dhMZService = new DHMZService();
            Task<IEnumerable<Grad>> taskCity = dhMZService.GetWeatherDataAsync();

            IEnumerable<Grad> cities = await taskCity;



            Grad? grad = cities.FirstOrDefault(x => x.GradIme == grads);


            return View("SelectedGrad", grad);

        }
    }
}
