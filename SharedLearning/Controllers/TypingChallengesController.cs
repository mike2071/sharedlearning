using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SharedLearning.Models;

namespace SharedLearning.Controllers
{
    public class TypingChallengesController : Controller
    {
        private SLContext db = new SLContext();

        // GET: TypingChallenges
        public ActionResult Index()
        {
            return View(db.TypingChallenges.ToList());
        }

        // GET: TypingChallenges/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypingChallenge typingChallenge = db.TypingChallenges.Find(id);
            if (typingChallenge == null)
            {
                return HttpNotFound();
            }
            return View(typingChallenge);
        }

        [Authorize(Roles = "SG-SharedLearningAdministrators")]
        // GET: TypingChallenges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypingChallenges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SG-SharedLearningAdministrators")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,WPM,Accuracy")] TypingChallenge typingChallenge)
        {
            if (ModelState.IsValid)
            {
                typingChallenge.Id = Guid.NewGuid();
                db.TypingChallenges.Add(typingChallenge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typingChallenge);
        }

        // GET: TypingChallenges/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypingChallenge typingChallenge = db.TypingChallenges.Find(id);
            if (typingChallenge == null)
            {
                return HttpNotFound();
            }
            return View(typingChallenge);
        }

        // POST: TypingChallenges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,WPM,Accuracy")] TypingChallenge typingChallenge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typingChallenge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typingChallenge);
        }

        // GET: TypingChallenges/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypingChallenge typingChallenge = db.TypingChallenges.Find(id);
            if (typingChallenge == null)
            {
                return HttpNotFound();
            }
            return View(typingChallenge);
        }

        // POST: TypingChallenges/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TypingChallenge typingChallenge = db.TypingChallenges.Find(id);
            db.TypingChallenges.Remove(typingChallenge);
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
