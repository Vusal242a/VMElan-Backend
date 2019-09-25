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
    public class SiteInfoesController : Controller
    {
        private VMElanDbContext db = new VMElanDbContext();

        [AvtorizationAttribute]
        // GET: Ad1000/SiteInfoes
        public ActionResult Index()
        {
            return View(db.SiteInfos.ToList());
        }

        // GET: Ad1000/SiteInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteInfo siteInfo = db.SiteInfos.Find(id);
            if (siteInfo == null)
            {
                return HttpNotFound();
            }
            return View(siteInfo);
        }

        // GET: Ad1000/SiteInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ad1000/SiteInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SiteInfo siteInfo, HttpPostedFileBase Logo, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                string i = Logo.SaveImage(Server.MapPath("~/Template/Media"));
                siteInfo.Logo = i;
                string s = Image.SaveImage(Server.MapPath("~/Template/Media"));
                siteInfo.Logo = s;
                siteInfo.CreatedDate = DateTime.Now;
                db.SiteInfos.Add(siteInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siteInfo);
        }

        // GET: Ad1000/SiteInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteInfo siteInfo = db.SiteInfos.Find(id);
            if (siteInfo == null)
            {
                return HttpNotFound();
            }
            return View(siteInfo);
        }

        // POST: Ad1000/SiteInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SiteInfo siteInfo , HttpPostedFileBase Logo, HttpPostedFileBase Image)
        {
            SiteInfo entity = db.SiteInfos.FirstOrDefault(w => w.Id == siteInfo.Id);
            if (ModelState.IsValid)
            {
                entity.Phone = siteInfo.Phone;
                entity.Email = siteInfo.Email;
                entity.Description = siteInfo.Description;
                entity.Location = siteInfo.Location;
                entity.WorkTime = siteInfo.WorkTime;
                entity.Facebook = siteInfo.Facebook;
                entity.Twitter = siteInfo.Twitter;
                entity.Instagram = siteInfo.Instagram;
                entity.LinkedIn = siteInfo.LinkedIn;
                entity.Pinterest = siteInfo.Pinterest;
                entity.OurQualityText = siteInfo.OurQualityText;
                entity.AboutUsText = siteInfo.AboutUsText;
                if (Logo == null)
                {
                    entity.Logo = entity.Logo;
                }
                else
                {
                    string i = Logo.SaveImage(Server.MapPath("~/Template/Media"));
                    entity.Logo = i;
                }
                if (Image == null)
                {
                    entity.Image = entity.Logo;
                }
                else
                {
                    string s = Image.SaveImage(Server.MapPath("~/Template/Media"));
                    entity.Image = s;
                }
                entity.ModifiedDate = DateTime.Now;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siteInfo);
        }

        // GET: Ad1000/SiteInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteInfo siteInfo = db.SiteInfos.Find(id);
            if (siteInfo == null)
            {
                return HttpNotFound();
            }
            return View(siteInfo);
        }

        // POST: Ad1000/SiteInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteInfo siteInfo = db.SiteInfos.Find(id);
            siteInfo.DeletedDate = DateTime.Now;
            db.SiteInfos.Remove(siteInfo);
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
