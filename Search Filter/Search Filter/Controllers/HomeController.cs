using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Search_Filter.Models;

namespace Search_Filter.Controllers
{
    public class HomeController : Controller
    {
        private SearchContext db = new SearchContext();

        // GET: Home
        public ActionResult Index(string SearchBy,string Search)
        {
            if (SearchBy=="Name")
            {
                var data = db.Searchs.Where(model => model.name.StartsWith(Search) ).ToList();
                return View(data);
            }
            else if (SearchBy == "Gender")
            {
                var data = db.Searchs.Where(model => model.gender.StartsWith(Search) ).ToList();
                return View(data);
            }
            else
            {
                var data = db.Searchs.ToList();
                return View(data);
            }
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Search search = db.Searchs.Find(id);
            if (search == null)
            {
                return HttpNotFound();
            }
            return View(search);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,gender,age")] Search search)
        {
            if (ModelState.IsValid)
            {
                db.Searchs.Add(search);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(search);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Search search = db.Searchs.Find(id);
            if (search == null)
            {
                return HttpNotFound();
            }
            return View(search);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,gender,age")] Search search)
        {
            if (ModelState.IsValid)
            {
                db.Entry(search).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(search);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Search search = db.Searchs.Find(id);
            if (search == null)
            {
                return HttpNotFound();
            }
            return View(search);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Search search = db.Searchs.Find(id);
            db.Searchs.Remove(search);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
