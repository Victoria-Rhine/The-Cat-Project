using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TheCatProject.DAL;
using TheCatProject.Models;
using TheCatProject.Models.ViewModels;

namespace TheCatProject.Controllers
{
    public class PTagsController : Controller
    {
        private CatsContext db = new CatsContext();

        // GET: PTags/Details/5
        public ActionResult Details(PTag ptag)
        {
            // do some query to join Cats, PTag, Personality Tables

            var personalityModel = db.Cats.Join(db.PTags.Where(p => p.CID == ptag.CID),
                c => c.ID, pt => pt.CID, (c, pt) => new { c, pt }).Join(db.Personalities,
                cpt => cpt.pt.PID, p => p.ID, (cpt, p) => new { cpt, p })
                .Select(m => new PersonalityDetailsView { CatID = m.cpt.c.ID, CatName = m.cpt.c.Name, 
                pTagID = m.cpt.pt.ID, PersonalityID = m.p.ID, PersonalityType = m.p.Type }).ToList();

            return View();
        }

        // GET: PTags/Create
        public ActionResult Create(int myID)
        {
            var cat = (from a in db.Cats where a.ID == myID select new { a.Name, a.ID }).ToList();

            ViewBag.CID = new SelectList(cat, "ID", "Name");
            ViewBag.PID = new SelectList(db.Personalities, "ID", "Type");
            return View();
        }

        // POST: PTags/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CID,PID")] PTag pTag)
        {
            if (ModelState.IsValid)
            {
                db.PTags.Add(pTag);
                db.SaveChanges();
            }

            ViewBag.CID = new SelectList(db.Cats, "ID", "Name", pTag.CID);
            ViewBag.PID = new SelectList(db.Personalities, "ID", "Type", pTag.PID);

            // redirect to details page for user confirmation or edits
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
            ViewBag.PID = new SelectList(db.Personalities, "ID", "Type", pTag.PID);
            return View(pTag);
        }

        // POST: PTags/Edit/5
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
