using Final.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class MainController : Controller
    {
        VMElanDbContext db = new VMElanDbContext();
        // GET: Main
        public ActionResult TopNav()
        {
            return PartialView("~/Views/Shared/Partial/_TopNav.cshtml", db.SiteInfos.FirstOrDefault());
        }

        public ActionResult LogoPart()
        {
            return PartialView("~/Views/Shared/Partial/_logo.cshtml", db.SiteInfos.FirstOrDefault());
        }

        public ActionResult FooterInfo()
        {
            return PartialView("~/Views/Shared/Partial/_FooterInfo.cshtml", db.SiteInfos.FirstOrDefault());
        }

        public ActionResult FooterCity()
        {
            return PartialView("~/Views/Shared/Partial/_FooterCity.cshtml", db.HomeInfos.DistinctBy(w => w.CityId).Take(6).ToList());
        }

        public ActionResult SingleListOwl(int id)
        {
            var home = db.HomeInfos.FirstOrDefault(w => w.Id == id);
            ViewBag.Vusal = db.Images.ToList();
            return PartialView("~/Views/Shared/Partial/_SingleListOwl.cshtml", home);
        }

        public ActionResult HomePropertyTag(int? id)
        {
            return PartialView("~/Views/Shared/Partial/_HomePropertyTag.cshtml", db.HomeToProperties.Where(h => h.HomeInfoId == id).ToList());
        }

        public ActionResult AccardionSingle(int? id)
        {
            ViewBag.Plan = db.PlanImages.ToList();
            return PartialView("~/Views/Shared/Partial/_AccardionSingle.cshtml", db.HomeInfos.FirstOrDefault(w=>w.Id == id));
        }
        
        public ActionResult RelatedPropertySingle()
        {
            return PartialView("~/Views/Shared/Partial/_RelatedPropertySingle.cshtml", db.HomeInfos.DistinctBy(w => w.Id).Take(4).ToList());
        }

        public ActionResult AboutUsAgent()
        {
            return PartialView("~/Views/Shared/Partial/_AboutUsAgent.cshtml", db.Agents.ToList());
        }
    }
}