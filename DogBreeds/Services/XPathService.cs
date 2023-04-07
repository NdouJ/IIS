using DogBreeds.Models;
using System.Linq.Expressions;
using System.Xml;
using System.Xml.XPath;
using static System.Net.Mime.MediaTypeNames;

namespace DogBreeds.Services
{
    
    public class XPathService
    {

        public static IList<DogBreed> Search(string dog)
        {

        
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load("../DogBreeds/ASSETS/dogsxml.xml");

            XPathNavigator nav = xmlDoc.CreateNavigator();

            string xpathExpr = $"//breedName[contains(., '{dog}')]";

            XPathNodeIterator nodes = nav.Select(xpathExpr);

            List<DogBreed> dogs = new List<DogBreed>();

            while (nodes.MoveNext())
            {
                XmlNode node = ((IHasXmlNode)nodes.Current).GetNode();

                
                    dogs.Add(new DogBreed
                    {
                        BreedName = node.InnerText,
                        BreedDescription = node.SelectSingleNode("../breedDescription")?.InnerText
                    });

                


            }

            return dogs;
        }


    }
}

