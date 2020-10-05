using System.Collections.Generic;
using PetalVinyls.API.Models.Vinyl;

namespace PetalVinyls.API.Services
{
    public interface IVinylService
    {
        List<VinylRelease> GetReleases();
        List<VinylRelease> GetReleases(ref string response, int qty);
    }
}