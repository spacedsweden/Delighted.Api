using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Delighted.Api.DelightedData {

    public class AddResult {
        public AddResult() {
            CreatedAt = (Int64)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
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
        public Int64 CreatedAt { get; set; }

        [JsonProperty("person_properties", DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Properties { get; set; }
    }
}