using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIS4200_Team13.DAL;
using MIS4200_Team13.Models;

namespace MIS4200_Team13.Controllers
{
    public class awardsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: awards
        public ActionResult Index()
        {
           //return View(db.award.Include(a=>a.Recognized).Include(b=>b.Recognizer).ToList()); //reconized doesnt have a path 
            return View(db.award.ToList());
            //comment above out and ask luce what this line is 
        }

        // GET: awards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            award award = db.award.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            return View(award);
        }

        // GET: awards/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.recognizer = new SelectList(db.profileData, "ID", "fullName");
            ViewBag.recognized = new SelectList(db.profileData, "ID", "fullName");
            return View();
        }

        // POST: awards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "awardID,awards,recognizer,recognized,recognitionDate")] award award)
        {
            if (ModelState.IsValid)
            {
                db.award.Add(award);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.recognizer = new SelectList(db.profileData, "ID", "fullName");
            ViewBag.recognized = new SelectList(db.profileData, "ID", "fullName");

            return View(award);
        }

        // GET: awards/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            ViewBag.recognizer = new SelectList(db.profileData, "ID", "fullName");
            ViewBag.recognized = new SelectList(db.profileData, "ID", "fullName");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            award award = db.award.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            return View(award);
        }

        // POST: awards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "awardID,awards,recognizer,recognized,recognitionDate")] award award)
        {
            if (ModelState.IsValid)
            {
                db.Entry(award).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.recognizer = new SelectList(db.profileData, "ID", "fullName");
            ViewBag.recognized = new SelectList(db.profileData, "ID", "fullName");
            return View(award);
        }

        // GET: awards/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            award award = db.award.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            return View(award);
        }

        // POST: awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            award award = db.award.Find(id);
            db.award.Remove(award);
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
