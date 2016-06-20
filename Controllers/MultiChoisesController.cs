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
    public class MultiChoisesController : Controller
    {
        private SurveyContext db = new SurveyContext();

        // GET: MultiChoises
        public ActionResult Index()
        {
            var questions = db.MultiChoises.Include(m => m.Survey);
            return View(questions.ToList());
        }

        // GET: MultiChoises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultiChoise multiChoise = db.MultiChoises.Find(id);
            if (multiChoise == null)
            {
                return HttpNotFound();
            }
            return View(multiChoise);
        }

        // GET: MultiChoises/Create
        public ActionResult Create()
        {
            ViewBag.SurveyID = new SelectList(db.Surveys, "ID", "Title");
            return View();
        }

        // POST: MultiChoises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SurveyID,Title,NoInSurvey,NullOrMultiAllowed")] MultiChoise multiChoise)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(multiChoise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SurveyID = new SelectList(db.Surveys, "ID", "Title", multiChoise.SurveyID);
            return View(multiChoise);
        }

        // GET: MultiChoises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultiChoise multiChoise = db.MultiChoises.Find(id);
            if (multiChoise == null)
            {
                return HttpNotFound();
            }
            ViewBag.SurveyID = new SelectList(db.Surveys, "ID", "Title", multiChoise.SurveyID);
            return View(multiChoise);
        }

        // POST: MultiChoises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SurveyID,Title,NoInSurvey,NullOrMultiAllowed")] MultiChoise multiChoise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(multiChoise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SurveyID = new SelectList(db.Surveys, "ID", "Title", multiChoise.SurveyID);
            return View(multiChoise);
        }

        // GET: MultiChoises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultiChoise multiChoise = db.MultiChoises.Find(id);
            if (multiChoise == null)
            {
                return HttpNotFound();
            }
            return View(multiChoise);
        }

        // POST: MultiChoises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MultiChoise multiChoise = db.MultiChoises.Find(id);
            db.Questions.Remove(multiChoise);
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
