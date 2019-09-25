using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final.AppCode.Filter;
using Final.Models;
using Final.Models.Entity;

namespace Final.Areas.Ad1000.Controllers
{
    public class HomePropertiesController : Controller
    {
        private VMElanDbContext db = new VMElanDbContext();

        [AvtorizationAttribute]
        // GET: Ad1000/HomeProperties
        public ActionResult Index()
        {
            return View(db.HomeProperties.ToList());
        }

        // GET: Ad1000/HomeProperties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeProperty homeProperty = db.HomeProperties.Find(id);
            if (homeProperty == null)
            {
                return HttpNotFound();
            }
            return View(homeProperty);
        }

        // GET: Ad1000/HomeProperties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ad1000/HomeProperties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreatedDate,CreatedId,ModifiedId,ModifiedDate,DeletedId,DeletedDate")] HomeProperty homeProperty)
        {
            if (ModelState.IsValid)
            {
                homeProperty.CreatedDate = DateTime.Now;
                db.HomeProperties.Add(homeProperty);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(homeProperty);
        }

        // GET: Ad1000/HomeProperties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeProperty homeProperty = db.HomeProperties.Find(id);
            if (homeProperty == null)
            {
                return HttpNotFound();
            }
            return View(homeProperty);
        }

        // POST: Ad1000/HomeProperties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatedDate,CreatedId,ModifiedId,ModifiedDate,DeletedId,DeletedDate")] HomeProperty homeProperty)
        {
            if (ModelState.IsValid)
            {
                homeProperty.ModifiedDate = DateTime.Now;
                db.Entry(homeProperty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homeProperty);
        }

        // GET: Ad1000/HomeProperties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeProperty homeProperty = db.HomeProperties.Find(id);
            if (homeProperty == null)
            {
                return HttpNotFound();
            }
            return View(homeProperty);
        }

        // POST: Ad1000/HomeProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HomeProperty homeProperty = db.HomeProperties.Find(id);
            homeProperty.DeletedDate = DateTime.Now;
            db.HomeProperties.Remove(homeProperty);
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
