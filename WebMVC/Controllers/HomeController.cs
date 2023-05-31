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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;       
        private readonly HttpClient client;
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory _httpClient)
        {
            _logger = logger;            
            client = _httpClient.CreateClient("webApi");
        }
        public IActionResult Index()
        {          
            List <Company> display= new List<Company>();            
            HttpResponseMessage response = client.GetAsync("api/apiCompanies").Result;
            if(response.IsSuccessStatusCode)
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
          
            var data = client.PostAsJsonAsync<Company>("/api/apiCompanies/addCompany",comp);
            var test = data.Result;
            if(test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
         
            Company display = new Company();
            HttpResponseMessage response = client.GetAsync("/api/apiCompanies/"+id).Result;
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
        public IActionResult Details(int id)
        {
          
            Company company = new Company();
            HttpResponseMessage responseForComp = client.GetAsync("/api/apiCompanies/" + id).Result;
            HttpResponseMessage responceForStaff = client.GetAsync("/api/apiStaffs").Result;
            if (responseForComp.IsSuccessStatusCode && responceForStaff.IsSuccessStatusCode)
            {
                var datac = responseForComp.Content.ReadAsAsync<Company>().Result;
                var datas = responceForStaff.Content.ReadAsAsync<List<Staff>>().Result;
                var relatedStaff = datas.Where(s => s.CompanyId == id).ToList();
                dynamic model = new ExpandoObject();
                model.company = datac;
                model.staff = relatedStaff;
                return View(model);                
            }
            return RedirectToAction("Index");
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