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
    public class PositionsController : Controller
    {
        private UserEntities db = new UserEntities();

        // GET: Positions
        public ActionResult Index()
        {
            //return View(db.Position.ToList());
            return View();
        }

        // Datatable Get Positions Data
        [HttpGet]
        public ActionResult GetPositionsData()
        {
            try
            {
                using (UserEntities db = new UserEntities())
                {
                    List<UserViewModel> positionsList = db.Position.Select(x => new UserViewModel
                    {
                        PositionID = x.PositionID,
                        PositionName = x.PositionName
                    }).ToList();

                    return Json(new { data = positionsList }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Positions/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Position.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // GET: Positions/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Positions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PositionID,PositionName")] Position position)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Position.Add(position);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again or Contact to the Administrator.");
            }

            return View(position);
        }

        // GET: Positions/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Position position = db.Position.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Positions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PositionID,PositionName")] Position position)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(position).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again or Contact to the Administrator.");
            }

            return View(position);
        }

        // GET: Positions/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Position.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Position position = db.Position.Find(id);
            db.Position.Remove(position);
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