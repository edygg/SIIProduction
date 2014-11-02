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
    public class AnnouncementController : Controller
    {
        private SIIContext db = new SIIContext();


        //Registro de visitas
        //GET
        public ActionResult Register()
        {
            ViewBag.Title = "Registro de Visitas";
            ViewBag.Campus = new SelectList(db.Campus.ToList(),"Code","Name");
            return View();
        }

        //Post, para almacenar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string campus, string tipo_fecha, string IntialDate, string FinalDate, string[] names, string[] dias, string tipo_entrada, string observaciones)
        {
            
            Response.Write(Request["campus"]);
            Response.Write(Request["tipo_fecha"]);
            Response.Write(Request["InitialDate"]);
            Response.Write(Request["FinalDate"]);
            Response.Write(Request["dia"]);
            Response.Write(Request["nombre"]);
            Response.Write(Request["tipo_entrada"]);
            Response.Write(Request["Observations"]);
            ViewBag.Campus = new SelectList(db.Campus.ToList(), "Code", "Name");

            return View();
        }

        //
        // GET: /Announcement/

        public ActionResult Index()
        {
            return View(db.Announcements.ToList());
        }

        //
        // GET: /Announcement/Details/5

        public ActionResult Details(int id = 0)
        {
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        //
        // GET: /Announcement/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Announcement/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                db.Announcements.Add(announcement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(announcement);
        }

        //
        // GET: /Announcement/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        //
        // POST: /Announcement/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(announcement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(announcement);
        }

        //
        // GET: /Announcement/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        //
        // POST: /Announcement/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Announcement announcement = db.Announcements.Find(id);
            db.Announcements.Remove(announcement);
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