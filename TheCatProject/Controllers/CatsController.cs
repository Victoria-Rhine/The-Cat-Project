using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TheCatProject.DAL;
using TheCatProject.Models;

namespace TheCatProject.Controllers
{
    public class CatsController : Controller
    {
        private CatsContext db = new CatsContext();

        public ActionResult Home()
        {
            return View();
        }

        // GET: Cats/Details/5
        public ActionResult Details(Cat catInfo)
        {
            int number = catInfo.ID;
            Cat cat = db.Cats.Find(catInfo.ID);

            return View(cat);
        }

        // GET: Cats/Create
        public ActionResult Create()
        {
            ViewBag.AnimalFriendID = new SelectList(db.AnimalFriendlinesses, "ID", "Response");
            ViewBag.BreedID = new SelectList(db.Breeds, "ID", "CatBreed");
            ViewBag.ColorID = new SelectList(db.Colors, "ID", "CatColor");
            ViewBag.LifestyleID = new SelectList(db.Lifestyles, "ID", "Type");
            ViewBag.PeopleFriendID = new SelectList(db.PeopleFriendlinesses, "ID", "Response");
            ViewBag.PlayID = new SelectList(db.Plays, "ID", "Activity");
            ViewBag.TraitsID_1 = new SelectList(db.Traits, "ID", "Type");
            ViewBag.TraitsID_2 = new SelectList(db.Traits, "ID", "Type");
            ViewBag.TraitsID_3 = new SelectList(db.Traits, "ID", "Type");
            ViewBag.WaterID = new SelectList(db.Waters, "ID", "Response");
            return View();
        }

        // POST: Cats/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Age,Sex,AnimalFriendID,BreedID,LifestyleID,ColorID,PlayID,TraitsID_1,TraitsID_2,TraitsID_3,PeopleFriendID,WaterID")] Cat cat)
        {
            if (ModelState.IsValid)
            {
                db.Cats.Add(cat);
                db.SaveChanges();              
            }

            ViewBag.AnimalFriendID = new SelectList(db.AnimalFriendlinesses, "ID", "Response", cat.AnimalFriendID);
            ViewBag.BreedID = new SelectList(db.Breeds, "ID", "CatBreed", cat.BreedID);
            ViewBag.ColorID = new SelectList(db.Colors, "ID", "CatColor", cat.ColorID);
            ViewBag.LifestyleID = new SelectList(db.Lifestyles, "ID", "Type", cat.LifestyleID);
            ViewBag.PeopleFriendID = new SelectList(db.PeopleFriendlinesses, "ID", "Response", cat.PeopleFriendID);
            ViewBag.PlayID = new SelectList(db.Plays, "ID", "Activity", cat.PlayID);
            ViewBag.TraitsID_1 = new SelectList(db.Traits, "ID", "Type", cat.TraitsID_1);
            ViewBag.TraitsID_2 = new SelectList(db.Traits, "ID", "Type", cat.TraitsID_2);
            ViewBag.TraitsID_3 = new SelectList(db.Traits, "ID", "Type", cat.TraitsID_3);
            ViewBag.WaterID = new SelectList(db.Waters, "ID", "Response", cat.WaterID);
            return RedirectToAction("Details", cat);
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
