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
   // [Authorize(Roles = "Guardia")]
    public class EntranceController : Controller
    {
        private SIIContext db = new SIIContext();

        //
        // GET: /Entrance/
        //[Authorize(Roles = "Guardia")]
        [AllowAnonymous]
        public ActionResult Index(string searchTerm = null)
        {

            DateTime h = DateTime.Now;
            var dayOfWeek = "";

            switch (h.DayOfWeek)
            { 
                case DayOfWeek.Monday:
                    dayOfWeek = "L";
                    break;
                case DayOfWeek.Tuesday:
                    dayOfWeek = "M";
                    break;
                case DayOfWeek.Wednesday:
                    dayOfWeek = "X";
                    break;
                case DayOfWeek.Thursday:
                    dayOfWeek = "J";
                    break;
                case DayOfWeek.Friday:
                    dayOfWeek = "V";
                    break;
                case DayOfWeek.Saturday:
                    dayOfWeek = "S";
                    break;
                case DayOfWeek.Sunday:
                    dayOfWeek = "D";
                    break;
            }

            ViewBag.dailyVisits = (from v in db.Visits
                                join an in db.Announcements on v.AnnouncementId equals an.Id
                                where (h >= an.InitialDate) && (h <= an.FinalDate) && (an.SpecificDays.Contains(dayOfWeek)) && (searchTerm == null ? v.FullName.StartsWith(searchTerm): false)
                                select new
                                {
                                    AnnouncementId = an.Id,
                                    Visitor = v.FullName,
                                    Visitor_id = v.Id,
                                    TypeEntrance = v.TypeEntrance,
                                    Observations = an.Observations
                                });
            
            return View();
        }

        [AllowAnonymous]
        public ActionResult GetVisits()
        {
            //DateTime h = new DateTime(2014, 11, 17);
            DateTime h = DateTime.Now;
            var dayOfWeek = "";

            switch (h.DayOfWeek)
            { 
                case DayOfWeek.Monday:
                    dayOfWeek = "L";
                    break;
                case DayOfWeek.Tuesday:
                    dayOfWeek = "M";
                    break;
                case DayOfWeek.Wednesday:
                    dayOfWeek = "X";
                    break;
                case DayOfWeek.Thursday:
                    dayOfWeek = "J";
                    break;
                case DayOfWeek.Friday:
                    dayOfWeek = "V";
                    break;
                case DayOfWeek.Saturday:
                    dayOfWeek = "S";
                    break;
                case DayOfWeek.Sunday:
                    dayOfWeek = "D";
                    break;
            }

            var dailyVisits = (from v in db.Visits
                                join an in db.Announcements on v.AnnouncementId equals an.Id
                                where (h >= an.InitialDate) && (h <= an.FinalDate) && (an.SpecificDays.Contains(dayOfWeek)) 
                                select new
                                {
                                    AnnouncementId = an.Id,
                                    Visitor = v.FullName,
                                    TypeEntrance = v.TypeEntrance,
                                    Observations = an.Observations
                                });
            return Json(dailyVisits, JsonRequestBehavior.AllowGet);

        }

        //aqui podes cambiar al rol que quieres que pueda verlo, lo deje asi para pruebas nada mas
        [HttpGet]
        [AllowAnonymous]
        public ActionResult DropDownBarrier()
        {
            ViewBag.Barrier = new SelectList(db.Barriers.Where(m => m.Dropped == false).ToList(), "Id", "Name");
            return View();
        }

        //
        // GET: /Entrance/Details/5
        [Authorize(Roles = "Guardia")]
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
        [Authorize(Roles = "Guardia")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Entrance/Create
        [Authorize(Roles = "Guardia")]
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
        [Authorize(Roles = "Guardia")]
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
        [Authorize(Roles = "Guardia")]
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
        [Authorize(Roles = "Guardia")]
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
        [Authorize(Roles = "Guardia")]
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