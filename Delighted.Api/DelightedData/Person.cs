using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Delighted.Api.DelightedData {
    public class Person {
        public Person() {
            LastSentAt = (Int64) (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        [JsonProperty("id",  DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("survey_scheduled_at", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public long? SurveyScheduledAt { get; set; }
        [JsonProperty("delay", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int Delay { get; set; }
        [JsonProperty("properties", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Properties { get; set; }
        [DefaultValue(true)]
        [JsonProperty("send" , DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public bool Send { get; set; }
        [JsonProperty("last_sent_at")]
        public Int64 LastSentAt { get; set; }

    }
    

}
