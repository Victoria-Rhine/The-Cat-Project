using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TheCatProject.DAL;
using TheCatProject.Models;

namespace TheCatProject.Controllers
{
    public class PTagsController : Controller
    {
        private CatsContext db = new CatsContext();

        // GET: PTags/Details/5
        public ActionResult Details(PTag ptag)
        {
            PTag pTag = db.PTags.Find(ptag.ID);

            return View(pTag);
        }

        // GET: PTags/Create
        public ActionResult Create(int myID)
        {
            var selectedCat = (from c in db.Cats where c.ID == myID select c.ID).FirstOrDefault();
            var selectedCatName = (from c in db.Cats where c.ID == myID select c.Name).FirstOrDefault();
            ViewBag.SelectedCat = selectedCat;
            ViewBag.CatName = selectedCatName;

            ViewBag.FirstTrait = new SelectList(db.Personalities, "ID", "Type");
            ViewBag.SecondTrait = new SelectList(db.Personalities, "ID", "Type");
            ViewBag.ThirdTrait = new SelectList(db.Personalities, "ID", "Type");
            return View();
        }

        // POST: PTags/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CID,FirstTrait,SecondTrait,ThirdTrait")] PTag pTag)
        {
            if (ModelState.IsValid)
            {
                db.PTags.Add(pTag);
                db.SaveChanges();
            }

            ViewBag.CID = new SelectList(db.Cats, "ID", "Name", pTag.CID);
            ViewBag.FirstTrait = new SelectList(db.Personalities, "ID", "Type", pTag.FirstTrait);
            ViewBag.SecondTrait = new SelectList(db.Personalities, "ID", "Type", pTag.SecondTrait);
            ViewBag.ThirdTrait = new SelectList(db.Personalities, "ID", "Type", pTag.ThirdTrait);
            return RedirectToAction("Details", pTag);
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
            ViewBag.FirstTrait = new SelectList(db.Personalities, "ID", "Type", pTag.FirstTrait);
            ViewBag.SecondTrait = new SelectList(db.Personalities, "ID", "Type", pTag.SecondTrait);
            ViewBag.ThirdTrait = new SelectList(db.Personalities, "ID", "Type", pTag.ThirdTrait);
            return View(pTag);
        }

        // POST: PTags/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CID,FirstTrait,SecondTrait,ThirdTrait")] PTag pTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CID = new SelectList(db.Cats, "ID", "Name", pTag.CID);
            ViewBag.FirstTrait = new SelectList(db.Personalities, "ID", "Type", pTag.FirstTrait);
            ViewBag.SecondTrait = new SelectList(db.Personalities, "ID", "Type", pTag.SecondTrait);
            ViewBag.ThirdTrait = new SelectList(db.Personalities, "ID", "Type", pTag.ThirdTrait);
            return View(pTag);
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
