using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NES.Models;

namespace NES.Controllers
{
    public class OrgUnitDepartmentController : Controller
    {
        private UserEntities db = new UserEntities();

        // GET: OrgUnitDepartment
        [HttpGet]
        public ActionResult Index()
        {
            //var orgUnit_Department = db.OrgUnit_Department.Include(o => o.OrgUnit).Include(o => o.Department);
            //return View(orgUnit_Department.ToList());
            return View();
        }

        [HttpGet]
        public ActionResult GetOrgUnitDepData()
        {
            try
            {
                var orgUnitDepartmentList = db.OrgUnitDepartmentView.ToList();
                return Json(new { data = orgUnitDepartmentList }, JsonRequestBehavior.AllowGet);
                //return Json(new { data = db.OrgUnitDepartmentView.ToList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: OrgUnitDepartment/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrgUnit_Department orgUnit_Department = db.OrgUnit_Department.Find(id);
            if (orgUnit_Department == null)
            {
                return HttpNotFound();
            }
            return View(orgUnit_Department);
        }

        // GET: OrgUnitDepartment/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Department, "DepartmentID", "DepartmentName");
            ViewBag.OrgUnitID = new SelectList(db.OrgUnit, "OrgUnitID", "OrgUnitName");
            return View();
        }

        // POST: OrgUnitDepartment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrgUnitID,DepartmentID,OrgDepID")] OrgUnit_Department orgUnitDepartment)
        {
            if (orgUnitDepartment is null)
            {
                throw new ArgumentNullException(nameof(orgUnitDepartment));
            }

            try
            {
                if (ModelState.IsValid)
                {
                    db.OrgUnit_Department.Add(orgUnitDepartment);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /*dataex*/)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again or Contact to the Administrator.");
            }

            ViewBag.DepartmentID = new SelectList(db.Department, "DepartmentID", "DepartmentName", orgUnitDepartment.DepartmentID);
            ViewBag.OrgUnitID = new SelectList(db.OrgUnit, "OrgUnitID", "OrgUnitName", orgUnitDepartment.OrgUnitID);
            return View(orgUnitDepartment);
        }

        // GET: OrgUnitDepartment/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrgUnit_Department orgUnit_Department = db.OrgUnit_Department.Find(id);
            if (orgUnit_Department == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Department, "DepartmentID", "DepartmentName", orgUnit_Department.DepartmentID);
            ViewBag.OrgUnitID = new SelectList(db.OrgUnit, "OrgUnitID", "OrgUnitName", orgUnit_Department.OrgUnitID);
            return View(orgUnit_Department);
        }

        // POST: OrgUnitDepartment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrgUnitID,DepartmentID,OrgDepID")] OrgUnit_Department orgUnitDepartment)
        {
            if (orgUnitDepartment is null)
            {
                throw new ArgumentNullException(nameof(orgUnitDepartment));
            }

            if (ModelState.IsValid)
            {
                db.Entry(orgUnitDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Department, "DepartmentID", "DepartmentName", orgUnitDepartment.DepartmentID);
            ViewBag.OrgUnitID = new SelectList(db.OrgUnit, "OrgUnitID", "OrgUnitName", orgUnitDepartment.OrgUnitID);
            return View(orgUnitDepartment);
        }

        // GET: OrgUnitDepartment/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrgUnit_Department orgUnit_Department = db.OrgUnit_Department.Find(id);
            if (orgUnit_Department == null)
            {
                return HttpNotFound();
            }
            return View(orgUnit_Department);
        }

        // POST: OrgUnitDepartment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrgUnit_Department orgUnit_Department = db.OrgUnit_Department.Find(id);
            db.OrgUnit_Department.Remove(orgUnit_Department);
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