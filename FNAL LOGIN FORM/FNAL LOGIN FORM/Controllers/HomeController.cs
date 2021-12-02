using FNAL_LOGIN_FORM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FNAL_LOGIN_FORM.Controllers
{
    public class HomeController : Controller
    {
        logincontext db = new logincontext();
        // GET: Home
        public ActionResult Index()
        {
            var a = db.LOGINS.ToList();
            return View(a);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LOGIN e)
        {
            if (ModelState.IsValid == true)
            {
                db.LOGINS.Add(e);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["datainsert"] = "<script>alert('Data is Inserted')</script>";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["datainsert"] = "<script>alert('Data is Not Inserted')</script>";
                }
            }
            return View();
        }



        public ActionResult Edit(int id)
        {
            var you = db.LOGINS.Where(modell => modell.LoginId == id).FirstOrDefault();
            return View(you);
        }
        [HttpPost]
        public ActionResult Edit(LOGIN e)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(e).State = EntityState.Modified;
                var you = db.SaveChanges();

                if (you > 0)
                {
                    TempData["update"] = "<script>alert('Data is Modified')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["update"] = "<script>alert('Data is Not Modified')</script>";
                }
            }
            return View();
        }





        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var you = db.LOGINS.Where(model => model.LoginId == id).FirstOrDefault();
                if (you != null)
                {
                    db.Entry(you).State = EntityState.Deleted;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["delete"] = "<script>alert('Data is Deleted')</script>";

                    }
                    else
                    {
                        TempData["delete"] = "<script>alert('Data is Not Deleted')</script>";

                    }
                }
            }
            return RedirectToAction("Index");
        }





        public ActionResult loginform()
        {
            return View();
        }
        [HttpPost]
        public ActionResult loginform(LOGIN L)
        {
            if (ModelState.IsValid == true)
            {


                var a = db.LOGINS.Where(m => m.LoginUserName == L.LoginUserName && m.LoginPassword == L.LoginPassword).FirstOrDefault();
                //int b = db.SaveChanges();
                if (a == null)
                {
                    TempData["ok"] = "<script>alert('Data is Not Modified')</script>";
                }
                else
                {
                    //TempData["ok"] = "<script>alert('Data is Modified')</script>";

                    Session["ok"] = L.LoginUserName;
                    return RedirectToAction("Index", "Home1");


                }
            }
            return View();
        }











    }
}