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
    public class SiteServicesController : Controller
    {
        private VMElanDbContext db = new VMElanDbContext();

        [AvtorizationAttribute]
        // GET: Ad1000/SiteServices
        public ActionResult Index()
        {
            return View(db.SiteServices.ToList());
        }

        // GET: Ad1000/SiteServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteServices siteServices = db.SiteServices.Find(id);
            if (siteServices == null)
            {
                return HttpNotFound();
            }
            return View(siteServices);
        }

        // GET: Ad1000/SiteServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ad1000/SiteServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,LogoClass,CreatedDate,CreatedId,ModifiedId,ModifiedDate,DeletedId,DeletedDate")] SiteServices siteServices)
        {
            if (ModelState.IsValid)
            {
                siteServices.CreatedDate = DateTime.Now;
                db.SiteServices.Add(siteServices);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteServices);
        }

        // GET: Ad1000/SiteServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteServices siteServices = db.SiteServices.Find(id);
            if (siteServices == null)
            {
                return HttpNotFound();
            }
            return View(siteServices);
        }

        // POST: Ad1000/SiteServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,LogoClass,CreatedDate,CreatedId,ModifiedId,ModifiedDate,DeletedId,DeletedDate")] SiteServices siteServices)
        {
            if (ModelState.IsValid)
            {
                siteServices.ModifiedDate = DateTime.Now;
                db.Entry(siteServices).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siteServices);
        }

        // GET: Ad1000/SiteServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteServices siteServices = db.SiteServices.Find(id);
            if (siteServices == null)
            {
                return HttpNotFound();
            }
            return View(siteServices);
        }

        // POST: Ad1000/SiteServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteServices siteServices = db.SiteServices.Find(id);
            siteServices.DeletedDate = DateTime.Now;
            db.SiteServices.Remove(siteServices);
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
