using System.Collections.Generic;
using System.Threading.Tasks;
using PetalVinyls.API.Models.Vinyl;

namespace PetalVinyls.API.Data
{
    public interface IPetalVinylsContext
    {
        Task<List<VinylRelease>> Releases();
    }
}