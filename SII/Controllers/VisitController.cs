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
    public class VisitController : Controller
    {
        private SIIContext db = new SIIContext();
        private IVisitRepository VisitRepo;

        public VisitController(IVisitRepository VisitRepo)
        {
            this.VisitRepo = VisitRepo;
        }

        //
        // GET: /Visit/
        [Authorize(Roles = "Administrador")]
        public ViewResult Index()
        {
            return View(VisitRepo.Visits.ToList());
        }

        //
        // GET: /Visit/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int id = 0)
        {
            Visit visit = VisitRepo.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        //
        // GET: /Visit/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Visit/Create
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Visit visit)
        {
            if (ModelState.IsValid)
            {
                VisitRepo.save(visit);
                return RedirectToAction("Index");
            }

            return View(visit);
        }

        //
        // GET: /Visit/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int id = 0)
        {
            Visit visit = VisitRepo.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        //
        // POST: /Visit/Edit/5
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Visit visit)
        {
            if (ModelState.IsValid)
            {
                VisitRepo.save(visit);
                return RedirectToAction("Index");
            }
            return View(visit);
        }

        //
        // GET: /Visit/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int id = 0)
        {
            Visit visit = VisitRepo.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        //
        // POST: /Visit/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisitRepo.delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}