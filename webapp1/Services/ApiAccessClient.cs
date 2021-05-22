using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp1.Services
{
    public class ApiAccessClient : IApiAccessClient
    {
        private readonly string ClientSecret;

        private readonly string ClientId;

        private readonly string Domain;

        private readonly string ApiIdentifier;

        public string AccessToken { get; private set; }

        private static RestClient Client;

        public ApiAccessClient(IConfiguration configuration)
        {
            ClientSecret = configuration["Auth0:ClientSecret"];
            ClientId = configuration["Auth0:ClientId"];
            Domain = configuration["Auth0:Domain"];
            ApiIdentifier = configuration["Auth0:ApiIdentifier"];
            Client = new RestClient("https://" + Domain + "/oauth/token");
            Authenticate();
        }

        public void Authenticate()
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("client_id", ClientId);
            request.AddParameter("client_secret", ClientSecret);
            request.AddParameter("audience", ApiIdentifier);
            IRestResponse response = Client.Execute(request);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
            AccessToken = jsonResponse.access_token;
        }

        public IRestResponse CallApi(string endpoint)
        {
            if(AccessToken == null || AccessToken == "Not found.")
            {
                Authenticate();
            }
            var client = new RestClient(ApiIdentifier + "/api/" + endpoint);
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer " + AccessToken);
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
