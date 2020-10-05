using Newtonsoft.Json;
using System.Collections.Generic;

namespace PetalVinyls.API.Models.Vinyl
{
    public class VinylReleaseBasicInformation
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("master_id")]
        public int MasterId { get; set; }

        [JsonProperty("master_url")]
        public string MasterUrl { get; set; }

        [JsonProperty("resource_url")]
        public string ResourceUrl { get; set; }

        [JsonProperty("thumb")]
        public string Thumb { get; set; }

        [JsonProperty("cover_image")]
        public string CoverImage { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("formats")]
        public List<VinylReleaseFormat> Formats { get; set; }

        [JsonProperty("labels")]
        public List<VinylReleaseLabel> Labels { get; set; }

        [JsonProperty("artists")]
        public List<VinylReleaseArtist> Artists { get; set; }

        [JsonProperty("genres")]
        public List<string> Genres { get; set; }

        [JsonProperty("styles")]
        public List<string> Styles { get; set; }

        public VinylReleaseBasicInformation()
        {
            Formats = new List<VinylReleaseFormat>();
            Labels = new List<VinylReleaseLabel>();
            Artists = new List<VinylReleaseArtist>();
            Genres = new List<string>();
            Styles = new List<string>();
        }
    }
}
