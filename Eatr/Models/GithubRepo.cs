using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Eatr.Models
{
    public class GithubRepo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Html_Url { get; set; }

        public static List<GithubRepo> GetTopStarred()
        {
            RestClient client = new RestClient("https://api.yelp.com/v3/");
            RestRequest request = new RestRequest("businesses/search", Method.GET);
            request.AddParameter("Latitude ", "37.786882");
            request.AddParameter("Longitude ", "-122.399972");
            request.AddParameter("Term ", "cupcakes");
            request.AddParameter("MaxResults", "40");
            request.AddParameter("OpenNow  ", "true");

            //request.AddHeader("User-Agent", "FrankNgo");
            RestResponse response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            return JsonConvert.DeserializeObject<List<GithubRepo>>(jsonResponse["test"].ToString());
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