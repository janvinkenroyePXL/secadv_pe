using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using webapp3.ViewModels;

namespace webapp3.Controllers
{
    public class PoemController : Controller
    {
        private readonly ILogger<PoemController> _logger;

        public PoemController(ILogger<PoemController> logger)
        {
            _logger = logger;
        }

        [Route("[action]")]
        public async Task<IActionResult> Poem()
        {
            var data = new PoemViewModel();

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new RestClient("https://localhost:44339/api/poems");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var model = response.Content;
                List<PoemViewModel> poemsList = JsonConvert.DeserializeObject<List<PoemViewModel>>(model);
                Random random = new Random();
                data = poemsList[random.Next(poemsList.Count)];
                return View(data);
            }
            else
            {
                throw new Exception("Unable to get content");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
