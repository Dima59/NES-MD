using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NES.Models;

namespace NES.Controllers
{
    public class DepartmentPositionController : Controller
    {
        private UserEntities db = new UserEntities();

        // GET: DepartmentPosition
        [HttpGet]
        public ActionResult Index()
        {
            //var department_Position = db.Department_Position.Include(d => d.Department).Include(d => d.Position).ToList();
            //return View(department_Position);
            return View();
        }

        [HttpGet]
        public ActionResult GetDepPosData()
        {
            try
            {
                var departmentPositionList = db.DepartmentPositionView.ToList();
                return Json(new { data = departmentPositionList }, JsonRequestBehavior.AllowGet);
                //return Json(new { data = db.DepartmentPositionView.ToList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: DepartmentPosition/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department_Position department_Position = db.Department_Position.Find(id);
            if (department_Position == null)
            {
                return HttpNotFound();
            }
            return View(department_Position);
        }

        // GET: DepartmentPosition/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Department, "DepartmentID", "DepartmentName");
            ViewBag.PositionID = new SelectList(db.Position, "PositionID", "PositionName");
            return View();
        }

        // POST: DepartmentPosition/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentID,PositionID,DepPosID")] Department_Position departmentPosition)
        {
            if (departmentPosition is null)
            {
                throw new ArgumentNullException(nameof(departmentPosition));
            }

            try
            {
                if (ModelState.IsValid)
                {
                    db.Department_Position.Add(departmentPosition);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /*dataex*/)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again or Contact to the Administrator.");
            }

            ViewBag.DepartmentID = new SelectList(db.Department, "DepartmentID", "DepartmentName", departmentPosition.DepartmentID);
            ViewBag.PositionID = new SelectList(db.Position, "PositionID", "PositionName", departmentPosition.PositionID);
            return View(departmentPosition);
        }

        // GET: DepartmentPosition/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department_Position department_Position = db.Department_Position.Find(id);
            if (department_Position == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Department, "DepartmentID", "DepartmentName", department_Position.DepartmentID);
            ViewBag.PositionID = new SelectList(db.Position, "PositionID", "PositionName", department_Position.PositionID);
            return View(department_Position);
        }

        // POST: DepartmentPosition/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentID,PositionID,DepPosID")] Department_Position departmentPosition)
        {
            if (departmentPosition is null)
            {
                throw new ArgumentNullException(nameof(departmentPosition));
            }

            if (ModelState.IsValid)
            {
                db.Entry(departmentPosition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Department, "DepartmentID", "DepartmentName", departmentPosition.DepartmentID);
            ViewBag.PositionID = new SelectList(db.Position, "PositionID", "PositionName", departmentPosition.PositionID);
            return View(departmentPosition);
        }

        // GET: DepartmentPosition/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department_Position department_Position = db.Department_Position.Find(id);
            if (department_Position == null)
            {
                return HttpNotFound();
            }
            return View(department_Position);
        }

        // POST: DepartmentPosition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department_Position department_Position = db.Department_Position.Find(id);
            db.Department_Position.Remove(department_Position);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}