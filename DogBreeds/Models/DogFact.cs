using Newtonsoft.Json;
using Org.BouncyCastle.Asn1;

namespace DogBreeds.Models
{
    public class DogFact
    {
         [JsonProperty("facts")]
        public List<string> Facts { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        public string Getfacts(){

            string s = "";
        foreach(var act in Facts){

                s += act;

        }

        return s;
        }

        public static explicit operator DogFact(string? v)
        {
            throw new NotImplementedException();
        }
    }
}
