using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cookies_remember.Models;

namespace Cookies_remember.Controllers
{
    public class HomeController : Controller
    {
        cookiesContext db = new cookiesContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Index(COOKIES c)
        {
                HttpCookie cooki = new HttpCookie("cook");
            if (c.Remember==true)
            {
                cooki["name"] = c.username;
                cooki["password"] = c.userpassword;
                cooki.Expires = DateTime.Now.AddYears(1);
                HttpContext.Response.Cookies.Add(cooki);
            }
            else
            {
                cooki.Expires = DateTime.Now.AddYears(-1);
                HttpContext.Response.Cookies.Add(cooki);
            }

            var check = db.COOKIESs.Where(m => m.username == c.username && m.userpassword == c.userpassword).FirstOrDefault();
            if (check !=null)
            {
                Session["usename"] = c.username;
                TempData["message"] = "<scrip>alert('Ok boss You have Done')</script>";
                return RedirectToAction("Index","Dash");
            }
            else
            {
                TempData["message"] = "<scrip>alert('No boss You have Not Done')</script>";
            }
                return View();
        }

    }

    
}