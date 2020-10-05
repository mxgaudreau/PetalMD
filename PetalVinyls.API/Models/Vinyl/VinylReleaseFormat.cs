using Newtonsoft.Json;
using System.Collections.Generic;

namespace PetalVinyls.API.Models.Vinyl
{
    public class VinylReleaseFormat
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("qty")]
        public string Qty { get; set; }

        [JsonProperty("descriptions")]
        public List<string> Descriptions { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        public VinylReleaseFormat()
        {
            Descriptions = new List<string>();
        }
    }
}
