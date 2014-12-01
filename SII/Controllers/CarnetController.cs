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

        //
        // GET: /Carnet/
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(db.Carnets.Where(m => m.Dropped == false).ToList());
        }

        //
        // GET: /Carnet/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int id = 0)
        {
            Carnet carnet = db.Carnets.Find(id);
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
                db.Carnets.Add(carnet);
                try
                {
                    db.SaveChanges();
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
            Carnet carnet = db.Carnets.Find(id);
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
                db.Entry(carnet).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
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
            Carnet carnet = db.Carnets.Find(id);
            carnet.Dropped = true;

            db.Entry(carnet).State = EntityState.Modified;

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