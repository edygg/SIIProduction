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
    public class DepartmentController : Controller
    {
        private SIIContext db = new SIIContext();
        private IDeparmentRepository DepartRepo;

        public DepartmentController(IDeparmentRepository DepartRepo)
        {
            this.DepartRepo = DepartRepo;
        }

        //
        // GET: /Deparmet/
        [Authorize(Roles = "Administrador")]
        public ViewResult Index()
        {
            return View(DepartRepo.Departments.Where(m => m.Dropped == false).ToList());
        }

        //
        // GET: /Deparmet/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int id = 0)
        {
            Department department = DepartRepo.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        //
        // GET: /Deparmet/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Deparmet/Create
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                DepartRepo.save(department);
                return RedirectToAction("Index");
            }

            return View(department);
        }

        //
        // GET: /Deparmet/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int id = 0)
        {
            Department department = DepartRepo.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        //
        // POST: /Deparmet/Edit/5
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                DepartRepo.save(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        //
        // GET: /Deparmet/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int id = 0)
        {
            Department department = DepartRepo.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        //
        // POST: /Deparmet/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartRepo.delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}