using Cookiess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookiess.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(user s)
        {
            if (ModelState.IsValid==true)
            {
                HttpCookie cookie = new HttpCookie("username");
                cookie.Value = s.name;
                cookie.Expires = DateTime.Now.AddYears(5);

                HttpContext.Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home1");
            }

           

            return View();
        }
    }
}