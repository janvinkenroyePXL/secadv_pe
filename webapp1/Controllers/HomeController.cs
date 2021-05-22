using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using webapp1.Services;
using webapp1.ViewModels;

namespace webapp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IConfiguration Configuration { get; private set; }

        private readonly IApiAccessClient _accessClient;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IApiAccessClient accessClient)
        {
            _logger = logger;
            Configuration = configuration;
            _accessClient = accessClient;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Students")]
        public IActionResult Students()
        {
            IRestResponse response = _accessClient.CallApi("students");

            if (response.IsSuccessful)
            {
                var model = response.Content;
                List<StudentViewModel> data = JsonConvert.DeserializeObject<List<StudentViewModel>>(model);
                return View(data);
            }
            else
            {
                throw new Exception("Unable to get content");
            }
        }

        [Route("[action]")]
        public IActionResult Poem()
        {
            IRestResponse response = _accessClient.CallApi("poems");

            if (response.IsSuccessful)
            {
                var model = response.Content;
                List<PoemViewModel> poemsList = JsonConvert.DeserializeObject<List<PoemViewModel>>(model);
                Random random = new Random();
                PoemViewModel data = poemsList[random.Next(poemsList.Count)];
                return View(data);
            }
            else
            {
                throw new Exception("Unable to get content");
            }
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
