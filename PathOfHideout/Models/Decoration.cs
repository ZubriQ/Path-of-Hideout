using Newtonsoft.Json;

namespace PathOfHideout.Models
{
    internal class Decoration
    {
        [JsonProperty("hash")]
        public long Hash { get; set; }

        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public long Y { get; set; }

        [JsonProperty("r")]
        public long R { get; set; }

        [JsonProperty("fv")]
        public long Fv { get; set; }
    }
}
