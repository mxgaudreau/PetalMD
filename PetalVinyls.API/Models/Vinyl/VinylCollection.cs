using Newtonsoft.Json;
using System.Collections.Generic;

namespace PetalVinyls.API.Models.Vinyl
{
    public class VinylCollection
    {
        [JsonProperty("pagination")]
        public CollectionPagination Pagination { get; set; }

        [JsonProperty("releases")]
        public List<VinylRelease> Releases { get; set; }

        public VinylCollection()
        {
            Releases = new List<VinylRelease>();
        }
    }
}
