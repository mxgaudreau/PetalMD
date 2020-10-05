using PetalVinyls.API.Data;
using PetalVinyls.API.Models.Vinyl;
using System;
using System.Collections.Generic;

namespace PetalVinyls.API.Services
{
    public class VinylService : IVinylService
    {
        private readonly IPetalVinylsContext _context;

        public VinylService(IPetalVinylsContext context)
        {
            _context = context;
        }

        public List<VinylRelease> GetReleases()
        {
            List<VinylRelease> releases = _context.Releases().Result;
            return releases;
        }

        public List<VinylRelease> GetReleases(ref string response, int qty)
        {
            CheckIfQtyIsValid(ref response, qty);
            if (!string.IsNullOrWhiteSpace(response))
                return null;

            List<VinylRelease> releases = GetReleases();
            CheckCollectionQty(ref response, qty, releases.Count);
            if (!string.IsNullOrWhiteSpace(response))
                return null;

            List<VinylRelease> randomReleases = new List<VinylRelease>();

            Random rnd = new Random();

            for (int i = 0; i < qty; i++)
                randomReleases.Add(releases[rnd.Next(releases.Count)]);

            return randomReleases;
        }

        private void CheckIfQtyIsValid(ref string response, int qty)
        {
            if (qty < 1 || qty > 5)
                response = "[Requête invalide] Veuillez spécifier une quantité entre 1 et 5.";
        }
        
        private void CheckCollectionQty(ref string response, int qty, int collectionQty)
        {
            if (qty > collectionQty)
                response = $"[Requête invalide] La collection ne comporte que {collectionQty} vinyls.";
        }
    }
}
