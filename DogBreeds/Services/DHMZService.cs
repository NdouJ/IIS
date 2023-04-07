using Azure.Core;
using Org.BouncyCastle.Ocsp;
using System;

using System.IO;

using System.Net;

using System.Xml;

using System.Xml.Linq;

using System.Net.Http;
using DogBreeds.Models;

namespace DogBreeds.Services
{
    public  class DHMZService
    {

        private readonly HttpClient client;
        private readonly string url = "https://vrijeme.hr/hrvatska_n.xml";
        public DHMZService()
        {
            client = new HttpClient();
        }

        public async Task<IEnumerable<Grad>> GetWeatherDataAsync()
        {
            HttpResponseMessage response = await client.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();


            XmlDocument xmlDoc = new XmlDocument();


            xmlDoc.LoadXml(responseBody);


            XmlNodeList name = xmlDoc.GetElementsByTagName("GradIme");



            List<Grad> grads = new List<Grad>();

            var doc = XDocument.Parse(xmlDoc.OuterXml);



            var GradoviiTemp = (from r in doc.Root.Elements("Grad")

                                select new Grad()

                                {

                                    GradIme = (string)r.Element("GradIme"),

                                    // Temp = (string)r.Element("Podatci").Value.ToString()

                                    Temp = r.Element("Podatci").Element("Temp").Value

                                }



             ).ToList();




            return GradoviiTemp; 

        }



    }
}
