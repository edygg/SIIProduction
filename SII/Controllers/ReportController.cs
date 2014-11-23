using SII.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SII.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ReportController : Controller
    {
        private SIIContext db = new SIIContext();

        //
        // GET: /Report/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /AnnouncementsByDateRange
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public ActionResult AnnouncementsByDateRange()
        {
            ViewBag.Campus = new SelectList(db.Campus.Where(m => m.Dropped == false).ToList(), "Id", "Name");
            return View();
        }

        //
        // POST: /AnnouncementsByDateRange
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult AnnouncementsByDateRange(String id)
        {
            ViewBag.Campus = new SelectList(db.Campus.Where(m => m.Dropped == false).ToList(), "Id", "Name");

            var campus = int.Parse(Request["Campus"]);
            var iniDate = DateTime.ParseExact(Request["InitialDate_submit"], "yyyy/MM/dd", CultureInfo.InvariantCulture);
            var finalDate = DateTime.ParseExact(Request["FinalDate_submit"], "yyyy/MM/dd", CultureInfo.InvariantCulture);

            //Fecha única
            var visitsOnlyDate = (from visit in db.Visits
                              join an in db.Announcements on visit.AnnouncementId equals an.Id
                              where (an.CampusId == campus) && (an.InitialDate == an.FinalDate) && ((iniDate <= an.InitialDate) && (an.InitialDate <= finalDate))
                              select visit).ToList();
            //Rango de fechas
            var visitsRangeDate = (from visit in db.Visits
                                   join an in db.Announcements on visit.AnnouncementId equals an.Id
                                   where (an.CampusId == campus) && (an.InitialDate != an.FinalDate) && ((iniDate <= an.InitialDate) || (an.FinalDate <= finalDate))
                                   select visit).ToList();

            var visits = visitsOnlyDate.Concat(visitsRangeDate);

            return View(visits);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();            
            base.Dispose(disposing);
        }

    }
}
