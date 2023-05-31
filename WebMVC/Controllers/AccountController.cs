using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: AccountController
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult LogIn()
        //{
        //    return RedirectToAction("Index", "Home");   
        //}

        // GET: AccountController/Details/5
        public ActionResult LogOut(int id)
        {
            return View();
        }
    }
}
