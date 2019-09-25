using Final.AppCode.Constant;
using Final.AppCode.Filter;
using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Final.Areas.Ad1000.Controllers
{
    public class LoginIndexController : Controller
    {
        private VMElanDbContext db = new VMElanDbContext();

        //[AvtorizationAttribute]
        // GET: Ad1000/LoginIndex
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(string email, string password)
        {
            //return Content(Crypto.HashPassword(password));
            if (email == null)
            {
                ViewBag.LoginError = "Please fill username";
                return View();
            }
            if (password == null)
            {
                ViewBag.LoginError = "Please fill password";
                return View();
            }
            var admin = db.Admins.FirstOrDefault(a => a.Email.ToUpper().Trim() == email.ToUpper().Trim());
            if (admin != null && Crypto.VerifyHashedPassword(admin.Password, password))
            {
                Session[SessionKey.Admin] = admin;

                return RedirectToAction("Index", "admin",new {
                    area="ad1000"
                });
            }
            return View();
        }
    }
}