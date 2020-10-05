using Moq;
using PetalVinyls.API.Data;
using PetalVinyls.API.Models.Vinyl;
using PetalVinyls.API.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetalVinyls.Tests.Services.Tests
{
    public class VinylServiceTests
    {
        private readonly IVinylService _vinylService;
        private readonly IVinylService _smallCollectionVinyllService;
        private string response = string.Empty;

        public VinylServiceTests()
        {
            Mock<IPetalVinylsContext> contextMock = new Mock<IPetalVinylsContext>();
            Mock<IPetalVinylsContext> smallContextMock = new Mock<IPetalVinylsContext>();

            List<VinylRelease> releases = new List<VinylRelease>
            {
                new VinylRelease
                {
                    Id = 1,
                    InstanceId = 12345,
                    DateAdded = DateTime.UtcNow,
                    Rating = 1,
                    BasicInformation = new VinylReleaseBasicInformation()
                },
                new VinylRelease
                {
                    Id = 2,
                    InstanceId = 12345,
                    DateAdded = DateTime.UtcNow,
                    Rating = 2,
                    BasicInformation = new VinylReleaseBasicInformation()
                },
                new VinylRelease
                {
                    Id = 3,
                    InstanceId = 12345,
                    DateAdded = DateTime.UtcNow,
                    Rating = 3,
                    BasicInformation = new VinylReleaseBasicInformation()
                },
                new VinylRelease
                {
                    Id = 4,
                    InstanceId = 12345,
                    DateAdded = DateTime.UtcNow,
                    Rating = 4,
                    BasicInformation = new VinylReleaseBasicInformation()
                },
                new VinylRelease
                {
                    Id = 5,
                    InstanceId = 12345,
                    DateAdded = DateTime.UtcNow,
                    Rating = 5,
                    BasicInformation = new VinylReleaseBasicInformation()
                },
                new VinylRelease
                {
                    Id = 6,
                    InstanceId = 12345,
                    DateAdded = DateTime.UtcNow,
                    Rating = 1,
                    BasicInformation = new VinylReleaseBasicInformation()
                },
                new VinylRelease
                {
                    Id = 7,
                    InstanceId = 12345,
                    DateAdded = DateTime.UtcNow,
                    Rating = 2,
                    BasicInformation = new VinylReleaseBasicInformation()
                },
                new VinylRelease
                {
                    Id = 8,
                    InstanceId = 12345,
                    DateAdded = DateTime.UtcNow,
                    Rating = 3,
                    BasicInformation = new VinylReleaseBasicInformation()
                },
                new VinylRelease
                {
                    Id = 9,
                    InstanceId = 12345,
                    DateAdded = DateTime.UtcNow,
                    Rating = 4,
                    BasicInformation = new VinylReleaseBasicInformation()
                },
                new VinylRelease
                {
                    Id = 10,
                    InstanceId = 12345,
                    DateAdded = DateTime.UtcNow,
                    Rating = 5,
                    BasicInformation = new VinylReleaseBasicInformation()
                }
            };
            List<VinylRelease> smallListRelease = new List<VinylRelease>
            {
                new VinylRelease
                {
                    Id = 1,
                    InstanceId = 12345,
                    DateAdded = DateTime.UtcNow,
                    Rating = 1,
                    BasicInformation = new VinylReleaseBasicInformation()
                },
                new VinylRelease
                {
                    Id = 2,
                    InstanceId = 12345,
                    DateAdded = DateTime.UtcNow,
                    Rating = 2,
                    BasicInformation = new VinylReleaseBasicInformation()
                }
            };

            contextMock.Setup(c => c.Releases()).ReturnsAsync(releases);
            contextMock.SetupAllProperties();
            smallContextMock.Setup(c => c.Releases()).ReturnsAsync(smallListRelease);
            smallContextMock.SetupAllProperties();
            _vinylService = new VinylService(contextMock.Object);
            _smallCollectionVinyllService = new VinylService(smallContextMock.Object);
        }

        [Fact]
        public void GetReleases_returnsReleases()
        {
            List<VinylRelease> releases = _vinylService.GetReleases();

            Assert.True(releases.Count == 10);
        }

        [Fact]
        public void GetReleases_returnsInvalidQuantityTooLow()
        {
            List<VinylRelease> releases = _vinylService.GetReleases(ref response, 0);

            Assert.True(response.Equals("[Requête invalide] Veuillez spécifier une quantité entre 1 et 5."));
            Assert.True(releases == null);
        }

        [Fact]
        public void GetReleases_returnsInvalidQuantityTooHigh()
        {
            List<VinylRelease> releases = _vinylService.GetReleases(ref response, 6);

            Assert.True(response.Equals("[Requête invalide] Veuillez spécifier une quantité entre 1 et 5."));
            Assert.True(releases == null);
        }

        [Fact]
        public void GetReleases_returnsCollectionQuantityTooLow()
        {
            List<VinylRelease> releases = _smallCollectionVinyllService.GetReleases(ref response, 5);

            Assert.True(response.Equals($"[Requête invalide] La collection ne comporte que {2} vinyls."));
            Assert.True(releases == null);
        }

        [Fact]
        public void GetReleases_returnsReleasesByValidQuantity()
        {
            List<VinylRelease> releases = _vinylService.GetReleases(ref response, 5);
            Assert.True(releases.Count == 5);

            releases = _vinylService.GetReleases(ref response, 1);
            Assert.True(releases.Count == 1);

            releases = _vinylService.GetReleases(ref response, 3);
            Assert.True(releases.Count == 3);

            Assert.True(response.Equals(string.Empty));
        }
    }
}
