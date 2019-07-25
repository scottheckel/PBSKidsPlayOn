using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace PBSKidsPlayOn
{
    public class Content
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        [JsonProperty("air_date")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime AirDate { get; set; }
        public ContentImages Images { get; set; }
        [JsonProperty("duration")]
        public int DurationSeconds { get; set; }
    }
}