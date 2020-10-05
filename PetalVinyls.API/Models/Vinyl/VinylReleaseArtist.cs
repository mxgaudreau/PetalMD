using Newtonsoft.Json;

namespace PetalVinyls.API.Models.Vinyl
{
    public class VinylReleaseArtist
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("anv")]
        public string Anv { get; set; }

        [JsonProperty("join")]
        public string Join { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("tracks")]
        public string Tracks { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("resource_url")]
        public string ResourceUrl { get; set; }
    }
}
