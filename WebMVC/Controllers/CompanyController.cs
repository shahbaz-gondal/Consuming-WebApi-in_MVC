using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using WebApi.Models;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class CompanyController : Controller
    {
        private readonly HttpClient client;
        public CompanyController(IHttpClientFactory _httpClient)
        {
            client = _httpClient.CreateClient("webApi");
        }
        public IActionResult Index()
        {
            List<Company> display = new List<Company>();
            HttpResponseMessage response = client.GetAsync("api/apiCompanies").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsAsync<List<Company>>();
                display = data.Result;
            }
            return View(display);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Company comp)
        {

            var data = client.PostAsJsonAsync<Company>("/api/apiCompanies/addCompany", comp);
            var test = data.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            Company display = new Company();
            HttpResponseMessage response = client.GetAsync("/api/apiCompanies/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsAsync<Company>();
                display = data.Result;
            }
            return View(display);
        }
        [HttpPost]
        public IActionResult Edit(Company comp)
        {

            int id = comp.CompanyId;
            HttpResponseMessage response = client.PutAsJsonAsync<Company>("/api/apiCompanies/" + id, comp).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {

            Company display = new Company();
            HttpResponseMessage response = client.GetAsync("/api/apiCompanies/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsAsync<Company>();
                display = data.Result;
                return View(display);
            }
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            HttpResponseMessage response = client.DeleteAsync("/api/apiCompanies/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}