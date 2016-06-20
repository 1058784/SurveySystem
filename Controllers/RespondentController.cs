using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SurveySystem.DAL;
using SurveySystem.Models;

namespace SurveySystem.Controllers
{
    public class RespondentController : Controller
    {
        private SurveyContext db = new SurveyContext();

        // GET: Respondent
        public ActionResult Index()
        {
            return View(db.Respondents.ToList());
        }

        // GET: Respondent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respondent respondent = db.Respondents.Find(id);
            if (respondent == null)
            {
                return HttpNotFound();
            }
            return View(respondent);
        }

        // GET: Respondent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Respondent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FName,LName,Gender,Age,MStatus")] Respondent respondent)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Respondents.Add(respondent);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(respondent);
        }

        // GET: Respondent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respondent respondent = db.Respondents.Find(id);
            if (respondent == null)
            {
                return HttpNotFound();
            }
            return View(respondent);
        }

        // POST: Respondent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FName,LName,Gender,Age,MStatus")] Respondent respondent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(respondent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(respondent);
        }

        // GET: Respondent/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Respondent respondent = db.Respondents.Find(id);
            if (respondent == null)
            {
                return HttpNotFound();
            }
            return View(respondent);
        }

        // POST: Respondent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Respondent respondent = db.Respondents.Find(id);
            db.Respondents.Remove(respondent);
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
