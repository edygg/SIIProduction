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
    public class CampusController : Controller
    {
        private SIIContext db = new SIIContext();
        private ICampusRepository CampusRepo;

      
        public CampusController(ICampusRepository CampusRepo)
        {
            this.CampusRepo =  CampusRepo;
        }

        //
        // GET: /Campus/
        [Authorize(Roles = "Administrador")]
        public ViewResult Index()
        {

            return View(CampusRepo.Campus.Where(i => i.Dropped == false).ToList());
        }

        //
        // GET: /Campus/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int id = 0)
        {
            Campus campus = CampusRepo.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        //
        // GET: /Campus/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Campus/Create
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Campus campus)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CampusRepo.save(campus);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "El código de campus ya existe.";
                    return View(campus);
                }
                // CampusRepo.save(campus);
                return RedirectToAction("Index");
            }

            return View(campus);
        }

        //
        // GET: /Campus/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int id = 0)
        {
            Campus campus = CampusRepo.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        //
        // POST: /Campus/Edit/5
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Campus campus)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CampusRepo.save(campus);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "El código de campus ya existe.";
                    return View(campus);
                }
                // CampusRepo.save(campus);
                return RedirectToAction("Index");
            }

            return View(campus);
        }

        //
        // GET: /Campus/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int id = 0)
        {
            Campus campus = CampusRepo.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        //
        // POST: /Campus/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            
            CampusRepo.delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}