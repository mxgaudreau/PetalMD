using Newtonsoft.Json;

namespace PetalVinyls.API.Models.Vinyl
{
    public class CollectionPagination
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("pages")]
        public int Pages { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("items")]
        public int Items { get; set; }

        [JsonProperty("urls")]
        public PaginationUrls Urls { get; set; }
    }
}