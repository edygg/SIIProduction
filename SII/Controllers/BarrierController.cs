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
        private IBarrierRepository BarrierRepo;

        public BarrierController(IBarrierRepository BarrierRepo )
        {
            this.BarrierRepo = BarrierRepo;
        }

        //
        // GET: /Barrier/

        public ViewResult Index()
        {
            return View(BarrierRepo.Barriers.Where(m => m.Dropped == false).ToList());
        }

        //
        // GET: /Barrier/Details/5

        public ActionResult Details(int id = 0)
        {
            Barrier barrier = BarrierRepo.Find(id);
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
                    BarrierRepo.save(barrier);
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
            Barrier barrier = BarrierRepo.Find(id);
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
                try
                {
                    BarrierRepo.save(barrier);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewBag.Error = "La dirección IP ya está asignada.";
                    return View(barrier);
                }
                
            }
            return View(barrier);
        }

        //
        // GET: /Barrier/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Barrier barrier = BarrierRepo.Find(id);
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
            BarrierRepo.delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}