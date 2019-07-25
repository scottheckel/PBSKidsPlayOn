namespace PBSKidsPlayOn
{
    public class FullEpisodeService
    {
        private IPlayOnHttpClient httpClient;

        public FullEpisodeService(IPlayOnHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public PlaylistData FetchPlaylist(string url)
        {
            return httpClient.FetchJSON<PlaylistData>(url);
        }
    }
}
