using System;
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
    public class TraitsController : Controller
    {
        private CatsContext db = new CatsContext();

        // GET: Traits
        public ActionResult Index()
        {
            var traits = db.Traits.Include(t => t.Breed).Include(t => t.Cat).Include(t => t.Color);
            return View(traits.ToList());
        }

        // GET: Traits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trait trait = db.Traits.Find(id);
            if (trait == null)
            {
                return HttpNotFound();
            }
            return View(trait);
        }

        // GET: Traits/Create
        public ActionResult Create()
        {
            ViewBag.BreedID = new SelectList(db.Breeds, "ID", "CatBreed");
            ViewBag.CatID = new SelectList(db.Cats, "ID", "Name");
            ViewBag.ColorID = new SelectList(db.Colors, "ID", "CatColor");
            return View();
        }

        // POST: Traits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CatID,ColorID,BreedID")] Trait trait)
        {
            if (ModelState.IsValid)
            {
                db.Traits.Add(trait);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BreedID = new SelectList(db.Breeds, "ID", "CatBreed", trait.BreedID);
            ViewBag.CatID = new SelectList(db.Cats, "ID", "Name", trait.CatID);
            ViewBag.ColorID = new SelectList(db.Colors, "ID", "CatColor", trait.ColorID);
            return View(trait);
        }

        // GET: Traits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trait trait = db.Traits.Find(id);
            if (trait == null)
            {
                return HttpNotFound();
            }
            ViewBag.BreedID = new SelectList(db.Breeds, "ID", "CatBreed", trait.BreedID);
            ViewBag.CatID = new SelectList(db.Cats, "ID", "Name", trait.CatID);
            ViewBag.ColorID = new SelectList(db.Colors, "ID", "CatColor", trait.ColorID);
            return View(trait);
        }

        // POST: Traits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CatID,ColorID,BreedID")] Trait trait)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trait).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BreedID = new SelectList(db.Breeds, "ID", "CatBreed", trait.BreedID);
            ViewBag.CatID = new SelectList(db.Cats, "ID", "Name", trait.CatID);
            ViewBag.ColorID = new SelectList(db.Colors, "ID", "CatColor", trait.ColorID);
            return View(trait);
        }

        // GET: Traits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trait trait = db.Traits.Find(id);
            if (trait == null)
            {
                return HttpNotFound();
            }
            return View(trait);
        }

        // POST: Traits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trait trait = db.Traits.Find(id);
            db.Traits.Remove(trait);
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
