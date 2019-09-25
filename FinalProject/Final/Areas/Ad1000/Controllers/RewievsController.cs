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
    public class RewievsController : Controller
    {
        private VMElanDbContext db = new VMElanDbContext();

        [AvtorizationAttribute]
        // GET: Ad1000/Rewievs
        public ActionResult Index()
        {
            return View(db.Rewievs.ToList());
        }

        // GET: Ad1000/Rewievs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rewiev rewiev = db.Rewievs.Find(id);
            if (rewiev == null)
            {
                return HttpNotFound();
            }
            return View(rewiev);
        }

        // GET: Ad1000/Rewievs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ad1000/Rewievs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Vacantion,Rate,Comment,Image,isPosted,CreatedDate,CreatedId,ModifiedId,ModifiedDate,DeletedId,DeletedDate")] Rewiev rewiev)
        {
            if (ModelState.IsValid)
            {
                db.Rewievs.Add(rewiev);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rewiev);
        }

        // GET: Ad1000/Rewievs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rewiev rewiev = db.Rewievs.Find(id);
            if (rewiev == null)
            {
                return HttpNotFound();
            }
            return View(rewiev);
        }

        // POST: Ad1000/Rewievs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Vacantion,Rate,Comment,Image,isPosted,CreatedDate,CreatedId,ModifiedId,ModifiedDate,DeletedId,DeletedDate")] Rewiev rewiev)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rewiev).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rewiev);
        }

        // GET: Ad1000/Rewievs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rewiev rewiev = db.Rewievs.Find(id);
            if (rewiev == null)
            {
                return HttpNotFound();
            }
            return View(rewiev);
        }

        // POST: Ad1000/Rewievs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rewiev rewiev = db.Rewievs.Find(id);
            db.Rewievs.Remove(rewiev);
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
