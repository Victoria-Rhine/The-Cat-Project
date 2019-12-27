using System.Linq;
using System.Web.Mvc;
using TheCatProject.DAL;

namespace TheCatProject.Controllers
{
    public class InformationController : Controller
    {
        private CatsContext db = new CatsContext();
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Guide()
        {
            ViewBag.Colors = db.Colors.ToList();
            ViewBag.Breeds = db.Breeds.ToList();
            ViewBag.Personalities = db.Personalities.ToList();
            
            return View();
        }

        public ActionResult Stats()
        {
            return View();
        }

        public ActionResult Breeds()
        {
            return View();
        }

        public ActionResult Colors()
        {
            return View();
        }

        public ActionResult Names()
        {
            return View();
        }

        public ActionResult Personalities()
        {
            return View();
        }

        public ActionResult Summary()
        {
            return View();
        }
    }
}