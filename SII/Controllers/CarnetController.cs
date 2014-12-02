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
    public class CarnetController : Controller
    {
        private SIIContext db = new SIIContext();
        private ICarnetRepository CarnetRepo;

        public CarnetController(ICarnetRepository CarnetRepo)
        {
            this.CarnetRepo = CarnetRepo;
        }
        //
        // GET: /Carnet/
        [Authorize(Roles = "Administrador")]
        public ViewResult Index()
        {
            return View(CarnetRepo.Carnets.Where(m => m.Dropped == false).ToList());
        }

        //
        // GET: /Carnet/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int id = 0)
        {
            Carnet carnet = CarnetRepo.Find(id);
            if (carnet == null)
            {
                return HttpNotFound();
            }
            return View(carnet);
        }

        //
        // GET: /Carnet/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.Campus = new SelectList(db.Campus.Where(m => m.Dropped == false).ToList(), "Id", "Name");
            return View();
        }

        //
        // POST: /Carnet/Create
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Carnet carnet)
        {
            ViewBag.Campus = new SelectList(db.Campus.Where(m => m.Dropped == false).ToList(), "Id", "Name");

            if (ModelState.IsValid)
            {                
                try
                {
                    CarnetRepo.save(carnet);
                } catch (Exception e)
                {
                    ViewBag.Error = "El campus ya posee este número de carnet.";
                    return View(carnet);
                }
                
                return RedirectToAction("Index");
            }

            return View(carnet);
        }

        //
        // GET: /Carnet/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int id = 0)
        {
            Carnet carnet = CarnetRepo.Find(id);
            ViewBag.Campus = new SelectList(db.Campus.Where(m => m.Dropped == false).ToList(), "Id", "Name");

            if (carnet == null)
            {
                return HttpNotFound();
            }
            return View(carnet);
        }

        //
        // POST: /Carnet/Edit/5
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Carnet carnet)
        {
            ViewBag.Campus = new SelectList(db.Campus.Where(m => m.Dropped == false).ToList(), "Id", "Name");

            if (ModelState.IsValid)
            {
                try
                {
                    CarnetRepo.save(carnet);
                }
                catch (Exception e)
                {
                    ViewBag.Error = "El campus ya posee este número de carnet.";
                    return View(carnet);
                }
                return RedirectToAction("Index");
            }
            return View(carnet);
        }

        //
        // GET: /Carnet/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int id = 0)
        {
            Carnet carnet = db.Carnets.Find(id);
            if (carnet == null)
            {
                return HttpNotFound();
            }
            return View(carnet);
        }

        //
        // POST: /Carnet/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarnetRepo.delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}