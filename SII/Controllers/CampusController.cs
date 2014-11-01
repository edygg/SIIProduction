using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SII.Models;

namespace SII.Controllers
{
    public class CampusController : Controller
    {
        private SIIContext db = new SIIContext();
        private ICampusRepository CampusRepo;

      
        public CampusController(ICampusRepository CampusRepo)
        {
            this.CampusRepo =  CampusRepo;
        }

        /*public CampusController()
        {
            this.CampusRepo = new EFCampusRepository();
        }*/

        //
        // GET: /Campus/

        public ViewResult Index()
        {

            return View(db.Campus.Where(i => i.Dropped == false).ToList());
        }

        //
        // GET: /Campus/Details/5

        public ActionResult Details(int id = 0)
        {
            Campus campus = db.Campus.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        //
        // GET: /Campus/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Campus/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Campus campus)
        {
            if (ModelState.IsValid)
            {
                db.Campus.Add(campus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campus);
        }

        //
        // GET: /Campus/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Campus campus = db.Campus.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        //
        // POST: /Campus/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Campus campus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(campus);
        }

        //
        // GET: /Campus/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Campus campus = db.Campus.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        //
        // POST: /Campus/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campus campus = db.Campus.Find(id);
            campus.Dropped = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}