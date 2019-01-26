using MediaMallTechnologies.PlayOn.Utilities;
using Newtonsoft.Json;

namespace PBSKidsPlayOn
{
    public class FullEpisodeService
    {
        public PlaylistData FetchPlaylist(string url)
        {
            InternetResponse resp = InternetRequest.DownloadHTML(url);
            string json = resp.HTML; // The xml fragment is malformed so fix it up.

            return JsonConvert.DeserializeObject<PlaylistData>(resp.HTML);
        }
    }
}
