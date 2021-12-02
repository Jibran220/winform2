using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookies_remember.Controllers
{
    public class DashController : Controller
    {
        // GET: Dash
        public ActionResult Index()
        {
            if (Session["usename"] == null)
            {
               
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        public ActionResult LOGUT()
        {
            if (Session["usename"] !=null)
            {
                Session.Abandon();
                return RedirectToAction("Index","Home");
            }
            return View();
        }
    }
}