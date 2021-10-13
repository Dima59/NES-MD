using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NES.Models;

namespace NES.Controllers
{
    public class OrgUnitsController : Controller
    {
        private readonly UserEntities db = new UserEntities();

        // GET: OrgUnits
        [HttpGet]
        public ActionResult Index()
        {
            //return View(db.OrgUnit.ToList());
            return View();
        }

        // Datatable Get Positions Data
        [HttpGet]
        public ActionResult GetOrgUnitsData()
        {
            try
            {
                using (UserEntities db = new UserEntities())
                {
                    List<UserViewModel> orgUnitsList = db.OrgUnit.Select(x => new UserViewModel
                    {
                        OrgUnitID = x.OrgUnitID,
                        OrgUnitName = x.OrgUnitName
                    }).ToList();

                    return Json(new { data = orgUnitsList }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: OrgUnits/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrgUnit orgUnit = db.OrgUnit.Find(id);
            if (orgUnit == null)
            {
                return HttpNotFound();
            }
            return View(orgUnit);
        }

        // GET: OrgUnits/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrgUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrgUnitID,OrgUnitName")] OrgUnit orgUnit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.OrgUnit.Add(orgUnit);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /*dataex*/)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again or Contact to the Administrator.");
            }

            return View(orgUnit);
        }

        // GET: OrgUnits/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            OrgUnit orgUnit = db.OrgUnit.Find(id);
            if (orgUnit == null)
            {
                return HttpNotFound();
            }
            return View(orgUnit);
        }

        // POST: OrgUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrgUnitID,OrgUnitName")] OrgUnit orgUnit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(orgUnit).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /*dataex*/)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again or Contact to the Administrator.");
            }

            return View(orgUnit);
        }

        // GET: OrgUnits/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrgUnit orgUnit = db.OrgUnit.Find(id);
            if (orgUnit == null)
            {
                return HttpNotFound();
            }
            return View(orgUnit);
        }

        // POST: OrgUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrgUnit orgUnit = db.OrgUnit.Find(id);
            db.OrgUnit.Remove(orgUnit);
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