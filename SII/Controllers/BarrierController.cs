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
    [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
        public ViewResult Index()
        {
            return View(BarrierRepo.Barriers.Where(m => m.Dropped == false).ToList());
        }

        //
        // GET: /Barrier/Details/5
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {            
            return View();
        }

        //
        // POST: /Barrier/Create
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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