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
    public class CategoriesController : Controller
    {
        private VMElanDbContext db = new VMElanDbContext();

        [AvtorizationAttribute]
        // GET: Ad1000/Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Ad1000/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories categories = db.Categories.Find(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // GET: Ad1000/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ad1000/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categories categories, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                string i = Image.SaveImage(Server.MapPath("~/Template/Media"));
                categories.Image = i;
                categories.CreatedDate = DateTime.Now;
                db.Categories.Add(categories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categories);
        }

        // GET: Ad1000/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories categories = db.Categories.Find(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // POST: Ad1000/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categories categories, HttpPostedFileBase Image)
        {
            Categories entity = db.Categories.FirstOrDefault(w => w.Id == categories.Id);
            if (ModelState.IsValid)
            {
                entity.Name = categories.Name;
                if (Image == null)
                {
                    entity.Image = entity.Image;
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
            return View(categories);
        }

        // GET: Ad1000/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories categories = db.Categories.Find(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // POST: Ad1000/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categories categories = db.Categories.Find(id);
            categories.DeletedDate = DateTime.Now;
            db.Categories.Remove(categories);
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
