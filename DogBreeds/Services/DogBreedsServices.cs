using DogBreeds.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace DogBreeds.Services
{

    public class DogBreedsServices
    {

    public async Task<IEnumerable<DogBreed>> GetDoggosListAsync(){

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://dogbreeddb.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "296ebc2835msha07ad0504e2916dp1a3f5fjsnaf60afca4e1c" },
        { "X-RapidAPI-Host", "dogbreeddb.p.rapidapi.com" },
    },
            };

            List<DogBreed> doggos = new List<DogBreed>();

            using (var response = await client.SendAsync(request))
            {

                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    doggos = JsonConvert.DeserializeObject<List<DogBreed>>(body);
                }


            }


            return doggos;

        }
    }
}
