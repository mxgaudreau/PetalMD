using Microsoft.AspNetCore.Mvc;
using PetalVinyls.API.Models.Vinyl;
using PetalVinyls.API.Services;
using System.Collections.Generic;

namespace PetalVinyls.API.Controllers
{
    [ApiController]
    [Route("api/vinylcollection")]
    public class VinylController : Controller
    {
        private readonly IVinylService _vinylService;

        public VinylController(IVinylService vinylService)
        {
            _vinylService = vinylService;
        }

        [HttpGet]
        [HttpHead]
        public IActionResult GetCollection()
        {
            List<VinylRelease> vinylReleases = _vinylService.GetReleases();

            return vinylReleases == null
                ? (IActionResult)NotFound()
                : Ok(vinylReleases);
        }

        [HttpGet("{qty}", Name = "GetVinyls")]
        public IActionResult GetVinyls(int qty)
        {
            string response = string.Empty;

            List<VinylRelease> releases = _vinylService.GetReleases(ref response, qty);

            return releases == null
                ? (IActionResult)BadRequest(response)
                : Ok(releases);
        }
    }
}
