using Newtonsoft.Json;
using RoadStatus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RoadStatus.ApiHelper
{
    public class AsyncApiContext : IAsyncApiContext
    {
        public async Task<IEnumerable<T>> GetObjectsAsync<T>(string baseUri, string actionString)
        {


            IEnumerable<T> returnValue =
             default;

            using (var client = new HttpClient())
            {
                // connection to the TFL api

                client.BaseAddress = new Uri(baseUri);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(actionString);

                response.EnsureSuccessStatusCode();

                returnValue = JsonConvert.DeserializeObject<IEnumerable<T>>(response.Content.ReadAsStringAsync()
                    .Result).ToList();
            }

            return returnValue;


        }
    }
}
