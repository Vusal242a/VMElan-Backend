using Final.Models;
using Final.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class HomeController : Controller
    {
        VMElanDbContext db = new VMElanDbContext();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "VMElan.az";
            ViewBag.Name = "";
            return View(db.HomeInfos.ToList());
        }

        public ActionResult AboutUs()
        {
            ViewBag.Title = "VMElan.az About Us";
            ViewBag.Name = "About Us";
            return View(db.SiteInfos.FirstOrDefault());
        }

        public ActionResult ContactUs()
        {
            ViewBag.Title = "VMElan.az Contact Us";
            ViewBag.Name = "Contact Us";
            return View();
        }
        public ActionResult ContactUsSubmit(string Name, string Email, string Message)
        {
            var newContact = new Contact();
            newContact.Name = Name;
            newContact.Email = Email;
            newContact.Message = Message;
            newContact.CreatedDate = DateTime.Now;
            db.Contacts.Add(newContact);
            db.SaveChanges();
            AppCode.Extension.Extension.SendMail("New Message from VMELAN", Message, "vusalim@code.edu.az");
            return RedirectToAction("Index");
        }

        public ActionResult SingleListing(int? id)
        {
            ViewBag.Title = "VMElan.az Single Listing";
            ViewBag.Name = "Single Listing";
            return View(db.HomeInfos.FirstOrDefault(w => w.Id == id));
        }

        public ActionResult FeaturedListing(int? Id, int? cityID, int pageIndex = 1, int pageSize = 4)
        {
            ViewBag.Title = "VMElan.az Featured Listing";
            ViewBag.Name = "Featured Listing";

            if (Id == null && cityID == null)
            {
                return View(db.HomeInfos.ToList());
            }
            var data = db.HomeInfos
                .OrderBy(w => w.Id).Where(s => s.DeletedDate == null)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToList();
            if (Id != null)
            {
                return View(db.HomeInfos.Where(w => w.CategoryId == Id).ToList());
            }
            else if (cityID != null)
            {
                return View(db.HomeInfos.Where(w => w.CityId == cityID).ToList());
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        [ChildActionOnly]
        public ActionResult Services()
        {
            return PartialView("~/Views/Shared/Partial/_Services.cshtml", db.SiteServices.OrderByDescending(w => w.Id).Take(3).ToList());
        }

        [ChildActionOnly]
        public ActionResult LookingProperty()
        {
            return PartialView("~/Views/Shared/Partial/_LookingProperty.cshtml", db.Categories.OrderByDescending(w => w.Id).ToList());
        }

        [ChildActionOnly]
        public ActionResult PopularPlaces()
        {
            return PartialView("~/Views/Shared/Partial/_PopularPlaces.cshtml", db.Cities.OrderByDescending(w => w.Id).Take(4).ToList());
        }

        [ChildActionOnly]
        public ActionResult RecentProperties()
        {
            return PartialView("~/Views/Shared/Partial/_RecentProperties.cshtml", db.HomeInfos.OrderByDescending(w => w.Id).Take(4).ToList());
        }

        [ChildActionOnly]
        public ActionResult FeaturedListingIndex()
        {
            return PartialView("~/Views/Shared/Partial/_FeaturedListing.cshtml", db.HomeInfos.OrderByDescending(w => w.Id).Take(6).ToList());
        }

        [ChildActionOnly]
        public ActionResult CategorySearchOption()
        {
            return PartialView("~/Views/Shared/Partial/_CategorySearchOption.cshtml", db.Categories.ToList());
        }

        [ChildActionOnly]
        public ActionResult CitySearchOption()
        {
            return PartialView("~/Views/Shared/Partial/_CitySearchOption.cshtml", db.Cities.ToList());
        }

        public ActionResult searchInFeaturedListing(string searchText, int? CityId, int? CategoryId)
        {
            if (searchText == "")
            {
                if (CityId != null && CategoryId != null)
                {
                    var searchListtt = db.HomeInfos.Where(w => w.DeletedDate == null && (w.CityId == CityId && w.CategoryId == CategoryId)).OrderByDescending(w => w.Id).ToList();
                    return View("FeaturedListing", searchListtt);
                }
                var searchListt = db.HomeInfos.Where(w => w.DeletedDate == null && (w.CityId == CityId || w.CategoryId == CategoryId)).OrderByDescending(w => w.Id).ToList();
                return View("FeaturedListing", searchListt);

            }
            else
            {
                if (CityId != null && CategoryId != null&& searchText!="")
                {
                    var searchListttt = db.HomeInfos.Where(w => w.DeletedDate == null && w.Name.Contains(searchText)&& w.CityId == CityId && w.CategoryId == CategoryId).OrderByDescending(w => w.Id).ToList();
                    return View("FeaturedListing", searchListttt);
                }
                if (CityId != null && CategoryId != null)
                {
                    var searchListtt = db.HomeInfos.Where(w => w.DeletedDate == null && (w.Name.Contains(searchText)||( w.CityId == CityId && w.CategoryId == CategoryId))).OrderByDescending(w => w.Id).ToList();
                    return View("FeaturedListing", searchListtt);
                }
                if (CityId != null || CategoryId != null)
                {
                    var searchListttt = db.HomeInfos.Where(w => w.DeletedDate == null && ((w.Name.Contains(searchText) && w.CityId == CityId) || (w.Name.Contains(searchText) && w.CategoryId == CategoryId))).OrderByDescending(w => w.Id).ToList();
                    return View("FeaturedListing", searchListttt);
                }
                var searchList = db.HomeInfos.Where(w => w.DeletedDate == null && (w.Name.Contains(searchText) || w.CityId == CityId || w.CategoryId == CategoryId)).OrderByDescending(w => w.Id).ToList();
                return View("FeaturedListing", searchList);
            }

        }
    }
}