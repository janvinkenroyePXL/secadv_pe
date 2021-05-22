using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using webapp2.ViewModels;
using webapp2.EditModels;
using Microsoft.AspNetCore.Authentication;
using RestSharp;

namespace webapp2.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        [Route("Students")]
        public async Task<IActionResult> Students()
        {
            var data = new List<StudentViewModel>();

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new RestClient("https://localhost:44339/api/students");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var model = response.Content;
                data = JsonConvert.DeserializeObject<List<StudentViewModel>>(model);
                return View(data);
            }
            else
            {
                throw new Exception("Unable to get content");
            }
        }

        [Route("Students/{id?}")]
        public async Task<IActionResult> Student(int id)
        {
            var data = new StudentViewModel();

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new RestClient("https://localhost:44339/api/students/" + id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var model = response.Content;
                data = JsonConvert.DeserializeObject<StudentViewModel>(model);
                return View(data);
            }
            else
            {
                throw new Exception("Unable to get content");
            }
        }

        [Route("Students/Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Students/Create")]
        [HttpPost]
        public async Task<IActionResult> Create(StudentEditModel model)
        {
            var json = JsonConvert.SerializeObject(model);

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new RestClient("https://localhost:44339/api/students/new");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer " + accessToken);
            request.AddJsonBody(json);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Added), new { fullName = model.FirstName + " " + model.Name });
            }
            else
            {
                throw new Exception("Unable to get content");
            }
        }

        [Route("Students/{id?}/Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = new StudentViewModel();

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new RestClient("https://localhost:44339/api/students/" + id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var model = response.Content;
                data = JsonConvert.DeserializeObject<StudentViewModel>(model);
                return View(data);
            }
            else
            {
                throw new Exception("Unable to get content");
            }
        }

        [Route("Students/{id?}/Edit")]
        [HttpPost]
        public async Task<IActionResult> Edit(StudentEditModel model, int id)
        {
            var json = JsonConvert.SerializeObject(model);

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new RestClient("https://localhost:44339/api/students/" + id + "/update");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer " + accessToken);
            request.AddJsonBody(json);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Updated), new { fullName = model.FirstName + " " + model.Name });
            }
            else
            {
                throw new Exception("Unable to get content");
            }
        }

        [Route("Students/{id?}/Delete")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = new StudentViewModel();

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new RestClient("https://localhost:44339/api/students/" + id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var model = response.Content;
                data = JsonConvert.DeserializeObject<StudentViewModel>(model);
                return View(data);
            }
            else
            {
                throw new Exception("Unable to get content");
            }
        }

        [Route("Students/{id?}/Delete")]
        [HttpPost]
        public async Task<IActionResult> Delete(StudentEditModel unusedModel, int id)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new RestClient("https://localhost:44339/api/students/" + id + "/delete");
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var model = response.Content;
                var data = JsonConvert.DeserializeObject<StudentViewModel>(model);
                return RedirectToAction(nameof(Deleted), new { fullName = data.FirstName + " " + data.Name });
            }
            else
            {
                throw new Exception("Unable to get content");
            }
        }

        [Route("Students/Added")]
        public IActionResult Added(string fullName)
        {
            return View("Added", fullName);
        }

        [Route("Students/Updated")]
        public IActionResult Updated(string fullName)
        {
            return View("Updated", fullName);
        }

        [Route("Students/Deleted")]
        public IActionResult Deleted(string fullName)
        {
            return View("Deleted", fullName);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
