using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final.AppCode.Extension;
using Final.AppCode.Filter;
using Final.Models;
using Final.Models.Entity;

namespace Final.Areas.Ad1000.Controllers
{
    public class CitiesController : Controller
    {
        private VMElanDbContext db = new VMElanDbContext();

        [AvtorizationAttribute]
        // GET: Ad1000/Cities
        public ActionResult Index()
        {
            return View(db.Cities.ToList());
        }

        // GET: Ad1000/Cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: Ad1000/Cities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ad1000/Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(City city, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                string i = Image.SaveImage(Server.MapPath("~/Template/Media"));
                city.Image = i;
                city.CreatedDate = DateTime.Now;

                db.Cities.Add(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(city);
        }

        // GET: Ad1000/Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: Ad1000/Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(City city,HttpPostedFileBase Image)
        {
            City entity = db.Cities.FirstOrDefault(w => w.Id == city.Id);
            if (ModelState.IsValid)
            {
                entity.Name = city.Name;
                if (Image == null)
                {
                    entity.Image = entity.Image; ;
                }
                else
                {
                    string i = Image.SaveImage(Server.MapPath("~/Template/Media"));
                    entity.Image = i;
                }
                entity.ModifiedDate = DateTime.Now;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(city);
        }

        // GET: Ad1000/Cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: Ad1000/Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            City city = db.Cities.Find(id);
            city.DeletedDate = DateTime.Now;
            db.Cities.Remove(city);
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
