using System.Collections.Generic;
using Newtonsoft.Json;

namespace Delighted.Api.DelightedData {
    public class AddResult {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }

        [JsonProperty("person")]
        public string PersonId { get; set; }

        [JsonProperty("score", DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore)]
        public int Score { get; set; }

        [JsonProperty("comment", DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Comment { get; set; }

        [JsonProperty("permalink", DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore)]
        public string PermaLink { get; set; }

        [JsonProperty("created_at", DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; set; }

        [JsonProperty("person_properties", DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Properties { get; set; }
    }
}