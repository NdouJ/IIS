using Azure;
using DogBreeds.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DogBreeds.Services
{
    public static class DogFactsService
    {


        public static async Task<DogFact> GetDogFact()
        {

            DogFact dogFactR;
          
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://dog-facts2.p.rapidapi.com/facts"),
                Headers =
    {
        { "X-RapidAPI-Key", "296ebc2835msha07ad0504e2916dp1a3f5fjsnaf60afca4e1c" },
        { "X-RapidAPI-Host", "dog-facts2.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                
          
                    var body = await response.Content.ReadAsStringAsync();

                     dogFactR = JsonConvert.DeserializeObject<DogFact>(body);
                 
                 

              
         
              
            }

            

            return dogFactR; 


        }
    }
}
