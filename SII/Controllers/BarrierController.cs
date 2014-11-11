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
    public class BarrierController : Controller
    {
        private SIIContext db = new SIIContext();

        //
        // GET: /Barrier/

        public ActionResult Index()
        {
            return View(db.Barriers.Where(m => m.Dropped == false).ToList());
        }

        //
        // GET: /Barrier/Details/5

        public ActionResult Details(int id = 0)
        {
            Barrier barrier = db.Barriers.Find(id);
            if (barrier == null)
            {
                return HttpNotFound();
            }
            return View(barrier);
        }

        //
        // GET: /Barrier/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Barrier/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Barrier barrier)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Barriers.Add(barrier);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewBag.Error = "La dirección IP ya está asignada.";
                    return View(barrier);
                }
                
                return RedirectToAction("Index");
            }

            return View(barrier);
        }

        //
        // GET: /Barrier/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Barrier barrier = db.Barriers.Find(id);
            if (barrier == null)
            {
                return HttpNotFound();
            }
            return View(barrier);
        }

        //
        // POST: /Barrier/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Barrier barrier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barrier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barrier);
        }

        //
        // GET: /Barrier/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Barrier barrier = db.Barriers.Find(id);
            if (barrier == null)
            {
                return HttpNotFound();
            }
            return View(barrier);
        }

        //
        // POST: /Barrier/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barrier barrier = db.Barriers.Find(id);
            barrier.Dropped = true;
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