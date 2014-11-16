﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SII.Models;

namespace SII.Controllers
{
    public class EntranceController : Controller
    {
        private SIIContext db = new SIIContext();

        //
        // GET: /Entrance/

        public ActionResult Index()
        {
            return View(db.Entrances.ToList());
        }

        public ActionResult GetVisits()
        {

            


            return null;
        }


        //
        // GET: /Entrance/Details/5

        public ActionResult Details(int id = 0)
        {
            Entrance entrance = db.Entrances.Find(id);
            if (entrance == null)
            {
                return HttpNotFound();
            }
            return View(entrance);
        }

        //
        // GET: /Entrance/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Entrance/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Entrance entrance)
        {
            if (ModelState.IsValid)
            {
                db.Entrances.Add(entrance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entrance);
        }

        //
        // GET: /Entrance/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Entrance entrance = db.Entrances.Find(id);
            if (entrance == null)
            {
                return HttpNotFound();
            }
            return View(entrance);
        }

        //
        // POST: /Entrance/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Entrance entrance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entrance);
        }

        //
        // GET: /Entrance/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Entrance entrance = db.Entrances.Find(id);
            if (entrance == null)
            {
                return HttpNotFound();
            }
            return View(entrance);
        }

        //
        // POST: /Entrance/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrance entrance = db.Entrances.Find(id);
            db.Entrances.Remove(entrance);
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