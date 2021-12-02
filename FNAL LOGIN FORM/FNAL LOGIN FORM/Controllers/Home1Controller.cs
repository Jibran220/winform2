using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FNAL_LOGIN_FORM.Controllers
{
    public class Home1Controller : Controller
    {
        // GET: Home1
        public ActionResult Index()
        {
            if (Session["ok"]==null)
            {
                return RedirectToAction("loginform", "Home");
            }
            return View();
        }
    }
}