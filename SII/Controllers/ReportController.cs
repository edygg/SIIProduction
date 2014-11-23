using SII.Models;
using System;
using System.Collections.Generic;
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
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();            
            base.Dispose(disposing);
        }

    }
}
