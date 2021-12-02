using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookiess.Controllers
{
    public class Home1Controller : Controller
    {
        // GET: Home1
        public ActionResult Index()
        {
            HttpCookie cook = Request.Cookies["username"];
            if (cook!=null)
            {
                ViewBag.name = Request.Cookies["username"].Value.ToString();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}