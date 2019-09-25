using Final.AppCode.Filter;
using System.Web.Mvc;
using Final.Models;

namespace Final.Areas.Ad1000.Controllers
{

    public class adminController : Controller
    {
        private VMElanDbContext db = new VMElanDbContext();

        [AvtorizationAttribute]
        // GET: Ad1000/admin
        public ActionResult Index()
        {
            return View();
        }
    }
}