using Code_First_Approah.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code_First_Approah.Controllers
{
    public class HomeController : Controller
    {
        EmployeeContext db = new EmployeeContext();

        // GET: Home
        public ActionResult Index1()
        {
            var data = db.Employees.ToList();
            return View(data);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee e)
        {
            if (ModelState.IsValid == true)
            {
                db.Employees.Add(e);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["datainsert"] = "<script>alert('Data is Inserted')</script>";
                    ModelState.Clear();
                    return RedirectToAction("Index1");
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
          var you= db.Employees.Where(modell => modell.EmpId == id).FirstOrDefault();
            return View(you);
        }
        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(e).State = EntityState.Modified;
                var you = db.SaveChanges();

                if (you > 0)
                {
                    TempData["update"] = "<script>alert('Data is Modified')</script>";
                    return RedirectToAction("Index1");
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
            if (id>0)
            {
            var you = db.Employees.Where(model => model.EmpId == id).FirstOrDefault();
                if (you !=null)
                {
                    db.Entry(you).State = EntityState.Deleted;
                   int a = db.SaveChanges();
                    if (a>0)
                    {
                           TempData["delete"] = "<script>alert('Data is Deleted')</script>";

                    }
                    else
                    {
                        TempData["delete"] = "<script>alert('Data is Not Deleted')</script>";

                    }
                }
            }
                    return RedirectToAction("Index1");
        }

    




















       // [HttpPost]
       //public ActionResult Delete(Employee e)
       // {
            
       //         db.Entry(e).State = EntityState.Deleted;
       //         int  a = db.SaveChanges();

       //         if (a > 0)
       //         {
       //         TempData["delete"] = "<script>alert('Data is Deleted')</script>";
       //         }
       //         else
       //         {
       //         TempData["delete"] = "<script>alert('Data is NotDeleted')</script>";

       //         }

       //     return RedirectToAction("Index1");
       // }
    }
}