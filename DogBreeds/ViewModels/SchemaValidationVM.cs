namespace DogBreeds.ViewModels
{
    public class SchemaValidationVM
    {
        public string MyXml { get; set; }
        public string MyVlalidationResoult { get; set; }

        public SchemaValidationVM(string myXml, string myVlalidationResoult)
        {
            MyXml = myXml;
            MyVlalidationResoult = myVlalidationResoult;
        }
    }
}
