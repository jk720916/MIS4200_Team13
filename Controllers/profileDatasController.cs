using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MIS4200_Team13.DAL;
using MIS4200_Team13.Models;

namespace MIS4200_Team13.Controllers
{
    public class profileDatasController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: profileDatas
        public ActionResult Index()
        {
            var newProfileData = db.profileData.Include(p => p.award).Where(q => q.ID == q.award.);
            return View(newProfileData.ToList());
            
        }

        // GET: profileDatas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profileData profileData = db.profileData.Find(id);
            if (profileData == null)
            {
                return HttpNotFound();
            }
            return View(profileData);
        }

        // GET: profileDatas/Create
        [Authorize]
        public ActionResult Create()
        {
           //ViewBag.title1 = new SelectList(db.profileData, "ID", "Setroles");//
            return View();
        }

        // POST: profileDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,lastName,firstName,businessUnit,title,dateHired,phoneNumber,email")] profileData profileData)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    Guid memberID;
                    Guid.TryParse(User.Identity.GetUserId(), out memberID);
                    profileData.ID = memberID;
                    // userData.ID = Guid.NewGuid();
                    db.profileData.Add(profileData);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        return View("duplicateUser");
                    }
                    return RedirectToAction("Index");
                }
            }
            return View(profileData);
        }

        // GET: profileDatas/Edit/5
        [Authorize]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profileData profileData = db.profileData.Find(id);
            if (profileData == null)
            {
                return HttpNotFound();
            }
            Guid memberId;
            Guid.TryParse(User.Identity.GetUserId(), out memberId);
            profileData profileData1 = db.profileData.Find(id);
            bool isAdmin = profileData.title == profileData.title1.admin;


            if (memberId == id || isAdmin)
            {
                return View(profileData);
            }
            else
            {
                return View("notAuthorized");
            }

           // return View(profileData);
        }

        // POST: profileDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,lastName,firstName,businessUnit,title,dateHired,phoneNumber,email")] profileData profileData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profileData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profileData);
        }

        // GET: profileDatas/Delete/5
        [Authorize]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                
            }
            profileData profileData = db.profileData.Find(id);
            if (profileData == null)
            {
                return HttpNotFound();
            }
            Guid memberId;
            Guid.TryParse(User.Identity.GetUserId(), out memberId);
            profileData loggedInUser = db.profileData.Find(memberId);
            bool isAdmin = loggedInUser.title == profileData.title;
            if (isAdmin)
            {
                return View(profileData);
            }
            else
            {
               return View("notAuthorizedDelete");
            }
        }

        // POST: profileDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            profileData profileData = db.profileData.Find(id);
            db.profileData.Remove(profileData);
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
