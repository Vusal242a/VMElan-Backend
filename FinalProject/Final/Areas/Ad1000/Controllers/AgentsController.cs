using Final.AppCode.Extension;
using Final.AppCode.Filter;
using Final.Models;
using Final.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace Final.Areas.Ad1000.Controllers
{
    public class AgentsController : Controller
    {
        private VMElanDbContext db = new VMElanDbContext();

        [AvtorizationAttribute]
        // GET: Ad1000/Agents
        public ActionResult Index()
        {
            return View(db.Agents.ToList());
        }

        // GET: Ad1000/Agents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agents agents = db.Agents.Find(id);
            if (agents == null)
            {
                return HttpNotFound();
            }
            return View(agents);
        }

        // GET: Ad1000/Agents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ad1000/Agents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Agents agents,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                string i = Image.SaveImage(Server.MapPath("~/Template/Media"));
                agents.Image = i;

                agents.CreatedDate = DateTime.Now;
                db.Agents.Add(agents);
                db.SaveChanges();
                return RedirectToAction("Index");


            }
            return View(agents);
        }

        // GET: Ad1000/Agents/Edit/5
        [ValidateInput(false)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agents agents = db.Agents.Find(id);
            if (agents == null)
            {
                return HttpNotFound();
            }
            return View(agents);
        }

        // POST: Ad1000/Agents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Agents agents, HttpPostedFileBase Image)
        {
            Agents entity = db.Agents.FirstOrDefault(w=> w.Id == agents.Id);
            if (ModelState.IsValid)
            {
                entity.Name = agents.Name;
                entity.Vacation = agents.Vacation;
                entity.Phone = agents.Phone;
                entity.Email = agents.Email;
                entity.FacebookLink = agents.FacebookLink;
                entity.FacebookLogo = agents.FacebookLogo;
                entity.TwitterLink = agents.TwitterLink;
                entity.TwitterLogo = agents.TwitterLogo;
                entity.InstagramLink = agents.InstagramLink;
                entity.InstagramLogo = agents.InstagramLogo;

                if (Image==null)
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
            return View(agents);
        }

        // GET: Ad1000/Agents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agents agents = db.Agents.Find(id);
            if (agents == null)
            {
                return HttpNotFound();
            }
            return View(agents);
        }

        // POST: Ad1000/Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agents agents = db.Agents.Find(id);
            agents.DeletedDate = DateTime.Now;
            db.Agents.Remove(agents);
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
