using Newtonsoft.Json;

namespace PetalVinyls.API.Models.Vinyl
{
    public class PaginationUrls
    {
        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}