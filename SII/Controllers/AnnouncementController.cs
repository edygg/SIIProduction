﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SII.Models;
using System.Globalization;
using System.Net.Http;
using System.Net;
using System.Text;

namespace SII.Controllers
{
    public class AnnouncementController : Controller
    {
        private SIIContext db = new SIIContext();
        private IAnnouncementRepository AnnouncementRepo;

        public AnnouncementController(IAnnouncementRepository AnnouncementRepo)
        {
            this.AnnouncementRepo = AnnouncementRepo;
        }


        //Registro de visitas
        //GET
        [HttpGet]
        [Authorize]
        public ActionResult Register()
        {
            ViewBag.Title = "Registro de Visitas";
            ViewBag.Campus = new SelectList(db.Campus.ToList(),"Id","Name");
            return View();
        }

        //Post, para almacenar
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public HttpResponseMessage Register(string id)
        {
            //salvar 1 persona


            string[] result = Request["nombre"].Split(',');
            string[] tipo = new string[result.Length];
            for (int i = 0; i < result.Length; i++)
            {
                tipo[i] = Request["tipo_entrada[" + i + "]"];
            }


            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result.ToString(), Encoding.UTF8, "text/plain");
            return resp;
            //Announcement an = new Announcement();

            //an.CampusId = Convert.ToInt32(Request["campus"]);

            //an.InitialDate = DateTime.ParseExact(Request["InitialDate_submit"], "yyyy-mm-dd", CultureInfo.InvariantCulture);

            //if (String.IsNullOrEmpty(Request["FinalDate_submit"]))
            //{
            //    an.FinalDate = DateTime.ParseExact(Request["InitialDate_submit"], "yyyy-mm-dd", CultureInfo.InvariantCulture);
            //}
            //else
            //{
            //    an.FinalDate = DateTime.ParseExact(Request["FinalDate_submit"], "yyyy-mm-dd", CultureInfo.InvariantCulture);
            //}
            
            
            //an.Observations = Request["Observations"];
                
            //    an.SpecificDays = Request["dia"];
            

            //db.Announcements.Add(an);
            //db.SaveChanges();

            //Visit visit = new Visit();
            //visit.AnnouncementId = an.Id;
            //visit.FullName = Request["nombre"];
            //visit.TypeEntrance = Request["tipo_entrada"];

            //db.Visits.Add(visit);
            //db.SaveChanges();
            
            //ViewBag.Campus = new SelectList(db.Campus.ToList(), "Code", "Name");

            //return View();
        }

        //
        // GET: /Announcement/

        public ViewResult Index()
        {
            return View(AnnouncementRepo.Announcements.ToList());
        }

        //
        // GET: /Announcement/Details/5

        public ActionResult Details(int id = 0)
        {
            Announcement announcement = AnnouncementRepo.Find(id);
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
                AnnouncementRepo.save(announcement);
                return RedirectToAction("Index");
            }

            return View(announcement);
        }

        //
        // GET: /Announcement/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Announcement announcement = AnnouncementRepo.Find(id);
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
                AnnouncementRepo.save(announcement);
                return RedirectToAction("Index");
            }
            return View(announcement);
        }

        //
        // GET: /Announcement/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Announcement announcement = AnnouncementRepo.Find(id);
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
            AnnouncementRepo.delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}