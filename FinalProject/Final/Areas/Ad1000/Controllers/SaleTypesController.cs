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
    public class SaleTypesController : Controller
    {
        private VMElanDbContext db = new VMElanDbContext();

        [AvtorizationAttribute]
        // GET: Ad1000/SaleTypes
        public ActionResult Index()
        {
            return View(db.SaleTypes.ToList());
        }

        // GET: Ad1000/SaleTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleType saleType = db.SaleTypes.Find(id);
            if (saleType == null)
            {
                return HttpNotFound();
            }
            return View(saleType);
        }

        // GET: Ad1000/SaleTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ad1000/SaleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreatedDate,CreatedId,ModifiedId,ModifiedDate,DeletedId,DeletedDate")] SaleType saleType)
        {
            if (ModelState.IsValid)
            {
                saleType.CreatedDate = DateTime.Now;
                db.SaleTypes.Add(saleType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(saleType);
        }

        // GET: Ad1000/SaleTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleType saleType = db.SaleTypes.Find(id);
            if (saleType == null)
            {
                return HttpNotFound();
            }
            return View(saleType);
        }

        // POST: Ad1000/SaleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatedDate,CreatedId,ModifiedId,ModifiedDate,DeletedId,DeletedDate")] SaleType saleType)
        {
            if (ModelState.IsValid)
            {
                saleType.ModifiedDate = DateTime.Now;
                db.Entry(saleType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(saleType);
        }

        // GET: Ad1000/SaleTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleType saleType = db.SaleTypes.Find(id);
            if (saleType == null)
            {
                return HttpNotFound();
            }
            return View(saleType);
        }

        // POST: Ad1000/SaleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaleType saleType = db.SaleTypes.Find(id);
            saleType.DeletedDate = DateTime.Now;
            db.SaleTypes.Remove(saleType);
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
