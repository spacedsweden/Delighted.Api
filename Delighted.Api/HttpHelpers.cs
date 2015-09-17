using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Delighted.Api {
    public static class QueryHelper {
        public static FormUrlEncodedContent BuildPostBody(this object postObject) {
            if (postObject == null) return null;
            var jsonstring = JsonConvert.SerializeObject(postObject);
            JObject jobject = JsonConvert.DeserializeObject<JObject>(jsonstring);

            // var q = jobject.Properties().Where(o => o.Type !=  JTokenType.Array && o.Value != null && !string.IsNullOrEmpty(o.Value.ToString())).Select(o => new KeyValuePair<string, string>(o.Name.ToLower(), o.Value.ToString())).ToList();
            var q = new Dictionary<string, string>();
            foreach (var p in jobject.Properties()) {

                if (p.Children<JObject>().Count() >0) {
                    foreach (var plist in p.Children<JObject>()) {
                        foreach (var prop in plist.Children<JProperty>())
                        {
                            q.Add(p.Name + "[" + prop.Name + "]", prop.Value.ToString());
                        }
                       
                    }
                } else {
                    q.Add(p.Name, p.Value.ToString());
                }
            }
            return new FormUrlEncodedContent(q);
        }

    }
}

