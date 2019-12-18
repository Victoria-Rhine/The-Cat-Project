using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using TheCatProject.DAL;
using TheCatProject.Models;

namespace TheCatProject.Controllers
{
    public class CatsController : Controller
    {
        private CatsContext db = new CatsContext();

        // GET: Cats/Details/5
        public ActionResult Details(Cat cat)
        {
            return View(cat);
        }

        // GET: Cats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cats/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Age,Sex")] Cat cat)
        {
            if (ModelState.IsValid)
            {
                db.Cats.Add(cat);
                db.SaveChanges();
            }

            return RedirectToAction("Details", cat);
        }

        // GET: Cats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat cat = db.Cats.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

        // POST: Cats/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Age,Sex")] Cat cat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat).State = EntityState.Modified;
                db.SaveChanges();

            }
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
