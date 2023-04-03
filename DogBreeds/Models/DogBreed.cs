using Newtonsoft.Json;

namespace DogBreeds.Models
{
    public class DogBreed
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("breedName")]
        public string BreedName { get; set; }

        [JsonProperty("breedType")]
        public string BreedType { get; set; }

        [JsonProperty("breedDescription")]
        public string BreedDescription { get; set; }

        [JsonProperty("furColor")]
        public string FurColor { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("minHeightInches")]
        public double MinHeightInches { get; set; }

        [JsonProperty("maxHeightInches")]
        public double MaxHeightInches { get; set; }

        [JsonProperty("minWeightPounds")]
        public double MinWeightPounds { get; set; }

        [JsonProperty("maxWeightPounds")]
        public long MaxWeightPounds { get; set; }

        [JsonProperty("minLifeSpan")]
        public long MinLifeSpan { get; set; }

        [JsonProperty("maxLifeSpan")]
        public long MaxLifeSpan { get; set; }

        [JsonProperty("imgThumb")]
        public Uri ImgThumb { get; set; }

        [JsonProperty("imgSourceURL")]
        public Uri ImgSourceUrl { get; set; }

        [JsonProperty("imgAttribution")]
        public string ImgAttribution { get; set; }

        [JsonProperty("imgCreativeCommons")]
        public bool ImgCreativeCommons { get; set; }
    }
}
