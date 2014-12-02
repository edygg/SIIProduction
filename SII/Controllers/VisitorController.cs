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
    public class VisitorController : Controller
    {
        private SIIContext db = new SIIContext();

        //
        // GET: /Visitor/

        public ActionResult Index()
        {
            ViewBag.BarrierId = Request["barrera"];
            ViewBag.Departments = new SelectList(db.Departments.Where(m => m.Dropped == false).ToList(), "Id", "Name");

            var today = DateTime.Now.Date;
            var tomorrow = DateTime.Now.AddDays(1).Date;

            var visitors = (from visi in db.Visitors
                            where (today <= visi.UpdatedAt) && (visi.UpdatedAt < tomorrow)
                            select visi);

            var visitorEntrances = new List<VisitorEntrance>();

            foreach (var v in visitors)
            {
                var lastEntrance = db.VisitorEntrances.Where(p => p.VisitorId == v.Id).OrderByDescending(p => p.CreatedAt).First();

                var state = lastEntrance.State == "Entrada" ? "Salida" : "Entrada";

                visitorEntrances.Add(new VisitorEntrance { VisitorId = v.Id, BarrierId = int.Parse(Request["barrera"]), DepartmentId = lastEntrance.DepartmentId, Carnet = lastEntrance.Carnet, State = state, ReturnCarnet = false });
            }

            ViewBag.VisitorEntrances = visitorEntrances;

            return View();
        }

        public ActionResult Mark(VisitorEntrance visitorEntrance) 
        {
            db.VisitorEntrances.Add(visitorEntrance);
            db.SaveChanges();
            return RedirectToAction("Index", "Visitor", new { barrera = visitorEntrance.BarrierId });
        }

        //
        // GET: /Visitor/GetNameByID

        public ActionResult GetNameByID(String id)
        {

            if(!String.IsNullOrEmpty(id)){
                id = id.Replace('-',' ');
                id = id.Trim();
                var n = (from p in db.IdCards
                         where p.Id.Contains(id)
                         select new
                         {
                             p.FirstName,
                             p.MiddleName,
                             p.FirstLastName,
                             p.SecondLastName
                         }).FirstOrDefault();
                if ( n == null){
                    return null;
                }
                else
                {
                    return Json(n, JsonRequestBehavior.AllowGet);
                }
            }
            return null;
           
        }

        //
        // GET: /Visitor/Details/5

        public ActionResult Details(int id = 0)
        {
            Visitor visitor = db.Visitors.Find(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        //
        // GET: /Visitor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Visitor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                ViewBag.BarrierId = Request["BarrierId"];
                ViewBag.Departments = new SelectList(db.Departments.Where(m => m.Dropped == false).ToList(), "Id", "Name");
                db.Visitors.Add(visitor);
                db.SaveChanges();
                db.VisitorEntrances.Add(new VisitorEntrance { VisitorId = visitor.Id, BarrierId = int.Parse(Request["BarrierId"]), DepartmentId = int.Parse(Request["DepartmentId"]), Carnet = int.Parse(Request["Carnet"]), State = "Entrada", ReturnCarnet = false });
                db.SaveChanges();

                var today = (new DateTime()).Date;
                var tomorrow = (new DateTime()).AddDays(1).Date;

                var visitors = (from visi in db.Visitors
                                    where (today <= visi.UpdatedAt) && (visi.UpdatedAt < tomorrow)
                                    select visi);

                var visitorEntrances = new List<VisitorEntrance>();

                foreach (var v in visitors)
                {
                    var lastEntrance = "Salida";

                    if (db.VisitorEntrances.Where(p => p.VisitorId == v.Id).Count() > 0)
                    {
                        lastEntrance = db.VisitorEntrances.Where(p => p.VisitorId == v.Id).OrderByDescending(p => p.CreatedAt).First().State;
                    }

                    var state = lastEntrance == "Entrada" ? "Salida" : "Entrada";
                    visitorEntrances.Add(new VisitorEntrance { VisitorId = v.Id, BarrierId = int.Parse(Request["BarrierId"]), DepartmentId = int.Parse(Request["DepartmentId"]), Carnet = int.Parse(Request["Carnet"]), State = state, ReturnCarnet = false });
                }

                ViewBag.VisitorEntrances = visitorEntrances;

                ModelState.Clear();
                return RedirectToAction("Index", "Visitor", new { barrera = Request["BarrierId"] }); ;
            }

            return View(visitor);
        }

        //
        // GET: /Visitor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Visitor visitor = db.Visitors.Find(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        //
        // POST: /Visitor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visitor);
        }

        //
        // GET: /Visitor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Visitor visitor = db.Visitors.Find(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        //
        // POST: /Visitor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visitor visitor = db.Visitors.Find(id);
            db.Visitors.Remove(visitor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        //[Authorize(Roles = "Guardia")]
        public ActionResult SelectBarrier()
        {
            ViewBag.Barrier = new SelectList(db.Barriers.Where(m => m.Dropped == false).ToList(), "Id", "Name");
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}