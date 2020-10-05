using Newtonsoft.Json;
using System;

namespace PetalVinyls.API.Models.Vinyl
{
    public class VinylRelease
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("instance_id")]
        public int InstanceId { get; set; }

        [JsonProperty("date_added")]
        public DateTime DateAdded { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("basic_information")]
        public VinylReleaseBasicInformation BasicInformation { get; set; }
    }
}
