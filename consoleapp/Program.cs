using Newtonsoft.Json;
using RestSharp;
using System;

namespace consoleapp
{
    class Program
    {
        static void Main(string[] args)
        {
            string accessToken = GetToken();
            string[] response = CallApi(accessToken);
            foreach (string line in response)
            {
                Console.WriteLine(line);
            }
        }

        private static string GetToken()
        {
            var client = new RestClient("https://ventielshop.dubbadub.be:8081/connect/token");
            // Bypass SSL validation
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", "Basic Og==");
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("client_id", "pxl-secadv");
            request.AddParameter("client_secret", "maarten_lust_geen_spruitjes");
            request.AddParameter("audience", "");
            IRestResponse response = client.Execute(request);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
            return jsonResponse.access_token;
        }

        private static string[] CallApi(string accessToken)
        {
            var client = new RestClient("https://ventielshop.dubbadub.be/fiets");
            // Bypass SSL validation
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + accessToken);
            IRestResponse response = client.Execute(request);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
            return jsonResponse.ToObject<string[]>();
        }
    }
}
