using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UnityEngine;

namespace gamingCloud
{

    public class ServerResponse
    {
        public int responseStatusCode;
        public string responseMessage;
        public bool IsSuccess;
    }
    public class HttpRequest : GCPolicy
    {

        static string baseURL = "https://api.gcsc.ir";
        // static string baseURL = "http://localhost:4000";
        // static string baseURL = "http://172.16.73.123:4000";
        static void SetHeader(HttpClient client)
        {
            foreach (KeyValuePair<string, string> item in GCPolicy.GetRequiredQueries(GCPolicy.QueryMode.HTTP))
            {
                client.DefaultRequestHeaders.Add(item.Key, item.Value);
            }




            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }



        async private static Task<HttpClient> Client()
        {
            string res = baseURL;
            if (res == null)
                res = baseURL;

            try
            {
                HttpClient client;
                baseURL = res;
                client = new HttpClient();
                client.BaseAddress = new Uri(baseURL);
                SetHeader(client);
                return client;

            }
            catch (System.Exception e)
            {
                Debug.LogError("error:" + e.Message);
            }
            return null;

        }

        async static private Task<ServerResponse> convertToResponseServer(HttpResponseMessage responseMessage)
        {
            string responseString = await responseMessage.Content.ReadAsStringAsync();
            ServerResponse serverResp = new ServerResponse();
            serverResp.IsSuccess = responseMessage.IsSuccessStatusCode;
            serverResp.responseMessage = responseString;
            serverResp.responseStatusCode = (int)responseMessage.StatusCode;

            return serverResp;
        }

        async static public Task<ServerResponse> GetRequestAsync(string route)
        {
            HttpClient client = await Client();
            HttpResponseMessage responseMessage = await client.GetAsync(route);
            return await convertToResponseServer(responseMessage);
        }

        async static public Task<ServerResponse> DeleteRequestAsync(string route)
        {
            HttpClient client = await Client();
            HttpResponseMessage responseMessage = await client.DeleteAsync(route);
            return await convertToResponseServer(responseMessage);
        }

        async static public Task<ServerResponse> PostRequestAsync(string route, Dictionary<string, dynamic> body)
        {
            HttpClient client = await Client();

            //HttpContent content = new FormUrlEncodedContent(body);
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(route, content);
            return await convertToResponseServer(responseMessage);
        }

        async static public Task<ServerResponse> PutRequestAsync(string route, Dictionary<string, dynamic> body)
        {
            HttpClient client = await Client();
            //var bodyContent = new FormUrlEncodedContent(body);
            var bodyContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await client.PutAsync(route, bodyContent);
            return await convertToResponseServer(responseMessage);
        }

    }
}