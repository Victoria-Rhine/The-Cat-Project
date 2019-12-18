﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheCatProject.DAL;
using TheCatProject.Models;

namespace TheCatProject.Controllers
{
    public class PTagsController : Controller
    {
        private CatsContext db = new CatsContext();

        // GET: PTags
        public ActionResult Index()
        {
            var pTags = db.PTags.Include(p => p.Cat).Include(p => p.Personality);
            return View(pTags.ToList());
        }

        // GET: PTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PTag pTag = db.PTags.Find(id);
            if (pTag == null)
            {
                return HttpNotFound();
            }
            return View(pTag);
        }

        // GET: PTags/Create
        public ActionResult Create()
        {
            ViewBag.CID = new SelectList(db.Cats, "ID", "Name");
            ViewBag.PID = new SelectList(db.Personalities, "ID", "Type");
            return View();
        }

        // POST: PTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CID,PID")] PTag pTag)
        {
            if (ModelState.IsValid)
            {
                db.PTags.Add(pTag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CID = new SelectList(db.Cats, "ID", "Name", pTag.CID);
            ViewBag.PID = new SelectList(db.Personalities, "ID", "Type", pTag.PID);
            return View(pTag);
        }

        // GET: PTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PTag pTag = db.PTags.Find(id);
            if (pTag == null)
            {
                return HttpNotFound();
            }
            ViewBag.CID = new SelectList(db.Cats, "ID", "Name", pTag.CID);
            ViewBag.PID = new SelectList(db.Personalities, "ID", "Type", pTag.PID);
            return View(pTag);
        }

        // POST: PTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CID,PID")] PTag pTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CID = new SelectList(db.Cats, "ID", "Name", pTag.CID);
            ViewBag.PID = new SelectList(db.Personalities, "ID", "Type", pTag.PID);
            return View(pTag);
        }

        // GET: PTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PTag pTag = db.PTags.Find(id);
            if (pTag == null)
            {
                return HttpNotFound();
            }
            return View(pTag);
        }

        // POST: PTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PTag pTag = db.PTags.Find(id);
            db.PTags.Remove(pTag);
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
