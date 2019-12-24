using System.Web.Mvc;
using TheCatProject.DAL;

namespace TheCatProject.Controllers
{
    public class InformationController : Controller
    {
        private CatsContext db = new CatsContext();
        // page to display information about the website
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Guide()
        {
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