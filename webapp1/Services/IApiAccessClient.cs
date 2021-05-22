using RestSharp;

namespace webapp1.Services
{
    public interface IApiAccessClient
    {

        string AccessToken { get; }

        void Authenticate();
        IRestResponse CallApi(string endpoint);
    }
}