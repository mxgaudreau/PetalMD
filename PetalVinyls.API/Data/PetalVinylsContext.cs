using Newtonsoft.Json;
using PetalVinyls.API.Models.Vinyl;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PetalVinyls.API.Data
{
    public class PetalVinylsContext : IPetalVinylsContext
    {
        private readonly string _baseUrl = "https://api.discogs.com/users/ausamerika";

        public async Task<List<VinylRelease>> Releases()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
                httpClient.DefaultRequestHeaders.Add("User-Agent", "PostmanRuntime/7.26.5");

                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"{_baseUrl}/collection/folders/0/releases"))
                {
                    var response = await httpClient.SendAsync(request);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<VinylCollection>(apiResponse).Releases;
                }
            }
        }
    }
}
