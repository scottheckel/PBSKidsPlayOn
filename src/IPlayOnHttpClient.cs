namespace PBSKidsPlayOn
{
    /// <summary>
    /// HTTP Client Useable through PlayOn
    /// </summary>
    public interface IPlayOnHttpClient
    {
        /// <summary>
        /// Fetch a JSON Url Endpoint
        /// </summary>
        /// <typeparam name="T">Type of Data at Endpoint</typeparam>
        /// <param name="url">URL to Deserialize</param>
        /// <returns>Deserialized JSON Object</returns>
        T FetchJSON<T>(string url);
    }
}