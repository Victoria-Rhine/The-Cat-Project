using System.Data;
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
