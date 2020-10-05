using Newtonsoft.Json;

namespace PetalVinyls.API.Models.Vinyl
{
    public class VinylReleaseLabel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("catno")]
        public string CatNo { get; set; }

        [JsonProperty("entity_type")]
        public string EntityType { get; set; }

        [JsonProperty("entity_type_name")]
        public string EntityTypeName { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("resource_url")]
        public string ResourceUrl { get; set; }
    }
}
