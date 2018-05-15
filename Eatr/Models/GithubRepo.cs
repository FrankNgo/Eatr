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


        public static YelpApi Recommend()
        {
            //RestClient client = new RestClient("https://api.yelp.com");
            //RestRequest request = new RestRequest("v3/businesses/north-india-restaurant-san-francisco", Method.GET);
            //request.AddParameter("MaxResults", "40");
            //request.AddParameter("OpenNow", "true");


            //RestResponse response = new RestResponse();

            //Task.Run(async () =>
            //{
            //    response = await GetResponseContentAsync(client, request) as RestResponse;
            //}).Wait();

            //JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            //return JsonConvert.DeserializeObject<List<YelpApi>>(jsonResponse["test"].ToString());



  var client = new RestClient();
            client.BaseUrl = new Uri("https://api.yelp.com");
      

            var request = new RestRequest();
            request.AddHeader("header", "Authorization: Bearer _l4M0A_gWgknLXhScqC6gzMQMrsvyU9xLCa3siFYWD5qGD6Rkr1-x23V5nch_nLIz5ok5Xxyr5J0XKqAurr_0rHMcHzGkJ6SheksKfH2K5_QT54cVkfbxCZ8EXLzWnYx");

            request.Resource = "v3/businesses/north-india-restaurant-san-francisco";

            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
           

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var repo = JsonConvert.DeserializeObject<YelpApi>(jsonResponse.ToString());
            return repo;

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