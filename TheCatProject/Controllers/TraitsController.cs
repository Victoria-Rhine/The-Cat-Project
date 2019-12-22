using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using TheCatProject.DAL;
using TheCatProject.Models;
using System.Linq;

namespace TheCatProject.Controllers
{
    public class TraitsController : Controller
    {
        private CatsContext db = new CatsContext();

        // GET: Traits/Details/5
        public ActionResult Details(Trait traits)
        {
            Trait trait = db.Traits.Find(traits.ID);
            var selectedCat = (from c in db.Cats where c.ID == traits.CatID select c.ID).FirstOrDefault();
            ViewBag.SelectedCat = selectedCat;

            return View(trait);
        }

        // GET: Traits/Create

        public ActionResult Create(int myID)
        {
            var selectedCat = (from c in db.Cats where c.ID == myID select c.ID).FirstOrDefault();
            var selectedCatName = (from c in db.Cats where c.ID == myID select c.Name).FirstOrDefault();
            ViewBag.SelectedCat = selectedCat;
            ViewBag.CatName = selectedCatName;
            ViewBag.BreedID = new SelectList(db.Breeds, "ID", "CatBreed");
            ViewBag.ColorID = new SelectList(db.Colors, "ID", "CatColor");

            return View();
        }

        // POST: Traits/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CatID,ColorID,BreedID")] Trait trait)
        {
            if (ModelState.IsValid)
            {
                db.Traits.Add(trait);
                db.SaveChanges();
                ViewBag.BreedID = new SelectList(db.Breeds, "ID", "CatBreed", trait.BreedID);
                ViewBag.CatID = new SelectList(db.Cats, "ID", "Name", trait.CatID);
                ViewBag.ColorID = new SelectList(db.Colors, "ID", "CatColor", trait.ColorID);
            }
        
            return RedirectToAction("Details", trait);
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

            var selectedCat = (from c in db.Cats where c.ID == trait.CatID select c.ID).FirstOrDefault();
            ViewBag.SelectedCat = selectedCat;

            var selectedCatName = (from c in db.Cats where c.ID == trait.CatID select c.Name).FirstOrDefault();
            ViewBag.CatName = selectedCatName;

            ViewBag.BreedID = new SelectList(db.Breeds, "ID", "CatBreed", trait.BreedID);
            ViewBag.ColorID = new SelectList(db.Colors, "ID", "CatColor", trait.ColorID);
            return View(trait);
        }

        // POST: Traits/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CatID,ColorID,BreedID")] Trait trait)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trait).State = EntityState.Modified;
                db.SaveChanges();
            }

            ViewBag.BreedID = new SelectList(db.Breeds, "ID", "CatBreed", trait.BreedID);
            ViewBag.ColorID = new SelectList(db.Colors, "ID", "CatColor", trait.ColorID);

            return RedirectToAction("Details", trait);
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
