using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Eatr.Models
{
   

    public class YelpApi
    {
        public string name { get; set; }
        public string image_url { get; set; }
        public string display_phone { get; set; }
        public string price { get; set; }
        public string rating { get; set; }

        public string searchPrice { get; set; }




        public static YelpApi Recommend()
        {

            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.yelp.com");


            var request = new RestRequest();
            request.AddHeader("Authorization","Bearer _l4M0A_gWgknLXhScqC6gzMQMrsvyU9xLCa3siFYWD5qGD6Rkr1-x23V5nch_nLIz5ok5Xxyr5J0XKqAurr_0rHMcHzGkJ6SheksKfH2K5_QT54cVkfbxCZ8EXLzWnYx");
            request.Resource = "/v3/businesses/deschutes-brewery-portland-public-house-portland";


            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var repoList = JsonConvert.DeserializeObject<YelpApi>(jsonResponse.ToString());
            return repoList;

        }

        public void SearchParams()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.yelp.com");
            var request = new RestRequest();
            request.AddHeader("Authorization", "Bearer _l4M0A_gWgknLXhScqC6gzMQMrsvyU9xLCa3siFYWD5qGD6Rkr1-x23V5nch_nLIz5ok5Xxyr5J0XKqAurr_0rHMcHzGkJ6SheksKfH2K5_QT54cVkfbxCZ8EXLzWnYx");
            request.Resource = "/v3/businesses/deschutes-brewery-portland-public-house-portland";

            request.AddParameter("searchPrice", searchPrice);
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

    }
}