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
    public class ScoreboardsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: Scoreboards
        public ActionResult Index()
        {
            return View(db.scoreboard.ToList());
        }

        // GET: Scoreboards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scoreboard scoreboard = db.scoreboard.Find(id);
            if (scoreboard == null)
            {
                return HttpNotFound();
            }
            return View(scoreboard);
        }

        // GET: Scoreboards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Scoreboards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "scoreBoardID")] Scoreboard scoreboard)
        {
            if (ModelState.IsValid)
            {
                db.scoreboard.Add(scoreboard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scoreboard);
        }

        // GET: Scoreboards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scoreboard scoreboard = db.scoreboard.Find(id);
            if (scoreboard == null)
            {
                return HttpNotFound();
            }
            return View(scoreboard);
        }

        // POST: Scoreboards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "scoreBoardID")] Scoreboard scoreboard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scoreboard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scoreboard);
        }

        // GET: Scoreboards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scoreboard scoreboard = db.scoreboard.Find(id);
            if (scoreboard == null)
            {
                return HttpNotFound();
            }
            return View(scoreboard);
        }

        // POST: Scoreboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scoreboard scoreboard = db.scoreboard.Find(id);
            db.scoreboard.Remove(scoreboard);
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
