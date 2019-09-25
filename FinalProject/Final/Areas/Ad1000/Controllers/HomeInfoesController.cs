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
    public class HomeInfoesController : Controller
    {
        private VMElanDbContext db = new VMElanDbContext();

        [AvtorizationAttribute]
        // GET: Ad1000/HomeInfoes
        public ActionResult Index()
        {
            var homeInfos = db.HomeInfos.Include(h => h.Agents).Include(h => h.Category).Include(h => h.SaleType).Include(h => h.City);
            ViewBag.HomeImage = db.Images.ToList();
            ViewBag.PlanImage = db.PlanImages.ToList();
            return View(homeInfos.ToList());
        }

        // GET: Ad1000/HomeInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeInfo homeInfo = db.HomeInfos.Find(id);
            if (homeInfo == null)
            {
                return HttpNotFound();
            }
            return View(homeInfo);
        }


        public ActionResult Search(string searchTerm)
        {
            var property = db.HomeProperties.ToList();
            if (searchTerm != null)
            {
                property = db.HomeProperties.Where(w => w.DeletedDate == null && w.Name.Contains(searchTerm)).ToList();
            }
            var modifiedData = property.Where(w => w.DeletedDate == null).Select(w => new
            {
                id = w.Id,
                text = w.Name
            });
            return Json(modifiedData, JsonRequestBehavior.AllowGet);
        }


        // GET: Ad1000/HomeInfoes/Create
        public ActionResult Create()
        {
            ViewBag.AgentsId = new SelectList(db.Agents, "Id", "Name");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.HomePropertyId = new SelectList(db.HomeProperties, "Id", "Name");
            ViewBag.SaleTypeId = new SelectList(db.SaleTypes, "Id", "Name");
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            return View();
        }

        // POST: Ad1000/HomeInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HomeInfo homeInfo,List<HttpPostedFileBase> HomeImages, List<HttpPostedFileBase> PlanImages,int [] DropdownProperty , HttpPostedFileBase backgroundImage)
        {
            if (HomeImages[0] == null && PlanImages[0] == null)
            {
                ModelState.AddModelError("Image","Please add at least one image");
                ModelState.AddModelError("PlanImage","Please add at least one image");
                ModelState.AddModelError("searchselect", "Please add at least one property");
                ViewBag.AgentsId = new SelectList(db.Agents, "Id", "Name");
                ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
                ViewBag.HomePropertyId = new SelectList(db.HomeProperties, "Id", "Name");
                ViewBag.SaleTypeId = new SelectList(db.SaleTypes, "Id", "Name");
                ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
                return View(homeInfo);
            }

            if (ModelState.IsValid)
            {
                string i = backgroundImage.SaveImage(Server.MapPath("~/Template/Media"));
                homeInfo.BackgroundImage = i;
                homeInfo.CreatedDate = DateTime.Now;
                db.HomeInfos.Add(homeInfo);
                db.SaveChanges();
                foreach (var item in HomeImages)
                {
                    Image images = new Image();
                    images.Photo = item.SaveImage(Server.MapPath("~/Template/Media"));
                    images.HomeInfoId = homeInfo.Id;
                    db.Images.Add(images);
                    db.SaveChanges();
                }
                foreach (var item in PlanImages)
                {
                    PlanImage planImage = new PlanImage();
                    planImage.Photo = item.SaveImage(Server.MapPath("~/Template/Media"));
                    planImage.HomeInfoId = homeInfo.Id;
                    db.PlanImages.Add(planImage);
                    db.SaveChanges();
                }
                foreach (var item in DropdownProperty)
                {
                    HomeToProperty homeToProperty = new HomeToProperty();
                    homeToProperty.HomeInfoId = homeInfo.Id;
                    homeToProperty.HomePropertyId = item;
                    db.HomeToProperties.Add(homeToProperty);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            ViewBag.AgentsId = new SelectList(db.Agents, "Id", "Name");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.HomePropertyId = new SelectList(db.HomeProperties, "Id", "Name");
            ViewBag.SaleTypeId = new SelectList(db.SaleTypes, "Id", "Name");
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            return View(homeInfo);
        }

        // GET: Ad1000/HomeInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeInfo homeInfo = db.HomeInfos.Find(id);
            if (homeInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgentsId = new SelectList(db.Agents, "Id", "Name", homeInfo.AgentsId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", homeInfo.CategoryId);
            ViewBag.SaleTypeId = new SelectList(db.SaleTypes, "Id", "Name", homeInfo.SaleTypeId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", homeInfo.CityId);
            return View(homeInfo);
        }

        // POST: Ad1000/HomeInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HomeInfo homeInfo , HttpPostedFileBase backgroundImage)
        {
            HomeInfo entity = db.HomeInfos.FirstOrDefault(w => w.Id == homeInfo.Id);
            if (ModelState.IsValid)
            {
                entity.Name = homeInfo.Name;
                entity.Price = homeInfo.Price;
                entity.Square = homeInfo.Square;
                entity.Bedroom = homeInfo.Bedroom;
                entity.Bathroom = homeInfo.Bathroom;
                entity.Garage = homeInfo.Garage;
                entity.Description = homeInfo.Description;
                entity.CategoryId = homeInfo.CategoryId;
                entity.CityId = homeInfo.CityId;
                entity.AgentsId = homeInfo.AgentsId;
                entity.SaleTypeId = homeInfo.SaleTypeId;

                if (backgroundImage == null)
                {
                    entity.BackgroundImage = entity.BackgroundImage; ;
                }
                else
                {
                    string i = backgroundImage.SaveImage(Server.MapPath("~/Template/Media"));
                    entity.BackgroundImage = i;
                }
                entity.ModifiedDate = DateTime.Now;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgentsId = new SelectList(db.Agents, "Id", "Name", homeInfo.AgentsId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", homeInfo.CategoryId);
            ViewBag.SaleTypeId = new SelectList(db.SaleTypes, "Id", "Name", homeInfo.SaleTypeId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", homeInfo.CityId);
            return View(homeInfo);
        }

        // GET: Ad1000/HomeInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeInfo homeInfo = db.HomeInfos.Find(id);
            if (homeInfo == null)
            {
                return HttpNotFound();
            }
            return View(homeInfo);
        }

        // POST: Ad1000/HomeInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HomeInfo homeInfo = db.HomeInfos.Find(id);
            homeInfo.DeletedDate = DateTime.Now;
            db.HomeInfos.Remove(homeInfo);
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
