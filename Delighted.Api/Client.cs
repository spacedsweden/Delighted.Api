using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Delighted.Api.DelightedData;

namespace Delighted.Api {
    public class Client {
        private readonly string _apiKey;
        private string baseUrl = "https://api.delighted.com/v1/";
        private string personPath = "people.json";
        private string surveyPath = "survey_responses.json";
        

        public Client() {
            throw  new Exception("Must start with an api Key");
        }

        public Client(string apiKey) {
            _apiKey = apiKey;
        }

        private HttpClient BuildClient() {
            var cl = new HttpClient();
            cl.BaseAddress = new Uri(baseUrl);
            var byteArray = Encoding.ASCII.GetBytes(_apiKey + ":");
            var header = new AuthenticationHeaderValue(
                       "Basic", Convert.ToBase64String(byteArray));
            cl.DefaultRequestHeaders.Authorization = header;
            return cl;
        }
        public async Task<Person> AddPerson(Person person) {
            
            
            using (var cl = BuildClient())
            {
                var body = person.BuildPostBody();
                var response = await cl.PostAsync(personPath, body);
                var sresult = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(sresult);
                if (response.IsSuccessStatusCode)
                {
                    
                    return await response.Content.ReadAsAsync<Person>();
                }
                else
                {
                    
                    Debug.WriteLine(response.ReasonPhrase);
                }
                return null;
            }
            
        }

        public async Task<AddResult> AddResult(AddResult result) {
            using (var cl = BuildClient())
            {
                var body = result.BuildPostBody();
                var response = await cl.PostAsync(surveyPath, body);
                var sresult = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(sresult);
                if (response.IsSuccessStatusCode) {

                    return await response.Content.ReadAsAsync<AddResult>();
                } else {

                    Debug.WriteLine(response.ReasonPhrase);
                }
                return null;
            }


        }
        private async Task<Person> DeletePerson(Person person) {
            using (var cl =BuildClient()) {
               
                var response = await cl.PostAsync(personPath, person.BuildPostBody());
                if (response.IsSuccessStatusCode) {
                    var sresult = await response.Content.ReadAsStringAsync();
                    return await response.Content.ReadAsAsync<Person>();
                }
                return null;
            }

        }

    }
}
