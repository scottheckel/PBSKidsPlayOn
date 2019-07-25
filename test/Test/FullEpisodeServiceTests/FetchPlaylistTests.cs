using System;
using System.Globalization;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PBSKidsPlayOn;

namespace Test.FullEpisodeServiceTests
{
    [TestClass]
    public class FetchPlaylistTests
    {
        [TestMethod]
        public void CanDownloadPlaylistTest()
        {
            var httpClient = new TestHttpClient(File.ReadAllText(@"FullEpisodeServiceTests\playlist.json"));
            var service = new FullEpisodeService(httpClient);
            var result = service.FetchPlaylist("https://cms-tc.pbskids.org/pbskidsvideoplaylists/daniel-tigers-neighborhood.json");
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Collections.Episodes.Content.Count);

            // Test one of the episodes
            var firstEpisode = result.Collections.Episodes.Content[0];
            Assert.AreEqual("2365842234", firstEpisode.Id);
            Assert.AreEqual("Daniel's Allergy/Allergies at School", firstEpisode.Title);
            Assert.IsTrue(firstEpisode.Description.StartsWith("When Daniel tries a peach for the first time"));
            Assert.AreEqual(new DateTime(2016, 9, 7), firstEpisode.AirDate.Date);
            Assert.AreEqual("https://image.pbs.org/video-assets/pbs-kids/daniel-tigers-neighborhood/238305/images/kids-mezzannine-16x9_837.jpg", firstEpisode.Images.Mezzanine);
            Assert.AreEqual(1353, firstEpisode.DurationSeconds);
        }

        private class TestHttpClient : IPlayOnHttpClient
        {
            private string htmlContent;

            public TestHttpClient(string htmlContent)
            {
                this.htmlContent = htmlContent;
            }

            public T FetchJSON<T>(string url)
            {
                return JsonConvert.DeserializeObject<T>(htmlContent);
            }
        }
    }
}
