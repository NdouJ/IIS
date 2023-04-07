using System.Drawing.Text;
using System.Xml;
using System.Xml.Schema;
using Commons.Xml.Relaxng;
using DogBreeds.ViewModels;

namespace DogBreeds.Services
{
    public class RNGService
    {


        public SchemaValidationVM ValidateXMLFile(IFormFile file)
        {
        

            bool isValid = true;
            string xml = "";
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                 xml = reader.ReadToEnd();

              
                using (StringReader stringReader = new StringReader(xml))
                {
                   
                    using (XmlTextReader xtrXml = new XmlTextReader(stringReader))
                    {
                        
                        using (XmlReader rngReader = XmlReader.Create("../DogBreeds/ASSETS/dogRNG.rng"))
                        {
                           
                            using (RelaxngValidatingReader vr = new RelaxngValidatingReader(xtrXml, rngReader))
                            {
                                try
                                {
                                    while (vr.Read())
                                    {
                                     
                                    }

                                    isValid = true;
                                }
                                catch (RelaxngException rngex)
                                {
                                    isValid = false;
                                }
                            }
                        }
                    }
                }
            }


            return new SchemaValidationVM(xml, isValid ? "valid" : "not valid");

        }



    }
}
