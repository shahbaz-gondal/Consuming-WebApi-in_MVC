using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApi.Models;

namespace WebMVC.Controllers
{
    public class StaffController : Controller
    {
        private readonly HttpClient Client;
        public StaffController(IHttpClientFactory _httpClient)
        {
            Client = _httpClient.CreateClient("webApi");
        }
        // GET: StaffController
        public ActionResult Index()
        {
            List<Staff> data = new List<Staff>();
            HttpResponseMessage response = Client.GetAsync("api/apiStaffs").Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsAsync<List<Staff>>().Result;
            }
            return View(data);
        }

        // GET: StaffController/Create
        public ActionResult Create()
        {
            HttpResponseMessage response = Client.GetAsync("api/apiCompanies").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsAsync<List<Company>>().Result;
                ViewBag.companies = new SelectList(data, "CompanyId", "CompanyName");
                return View();
            }
            return View();
        }

        // POST: StaffController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Staff staff)
        {
            HttpResponseMessage response = Client.PostAsJsonAsync("api/apiStaffs/addStaff", staff).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: StaffController/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = Client.GetAsync("api/apiStaffs/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                Staff data = response.Content.ReadAsAsync<Staff>().Result;
                HttpResponseMessage responsec = Client.GetAsync("api/apiCompanies").Result;
                List<Company> companies = responsec.Content.ReadAsAsync<List<Company>>().Result;
                ViewBag.Companies = new SelectList(companies, "CompanyId", "CompanyName");
                var myCompId = data.CompanyId;
                var myComp = companies.Where(x=>x.CompanyId == myCompId).FirstOrDefault();
                ViewData["myCompany"] = myComp.CompanyName;
                return View(data);
            }
            return RedirectToAction("Index");
        }

        // POST: StaffController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StaffController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
