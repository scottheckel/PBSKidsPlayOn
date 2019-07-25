using MediaMallTechnologies.PlayOn.Utilities;
using Newtonsoft.Json;

namespace PBSKidsPlayOn
{
    /// <summary>
    /// HTTP Client Useable through PlayOn
    /// </summary>
    public class PlayOnHttpClient : IPlayOnHttpClient
    {
        /// <summary>
        /// Fetch a JSON Url Endpoint
        /// </summary>
        /// <typeparam name="T">Type of Data at Endpoint</typeparam>
        /// <param name="url">URL to Deserialize</param>
        /// <returns>Deserialized JSON Object</returns>
        public T FetchJSON<T>(string url)
        {
            InternetResponse resp = InternetRequest.DownloadHTML(url);
            string json = resp.HTML;
            return JsonConvert.DeserializeObject<T>(resp.HTML);
        }
    }
}
