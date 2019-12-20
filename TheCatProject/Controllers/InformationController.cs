using System.Web.Mvc;

namespace TheCatProject.Controllers
{
    public class InformationController : Controller
    {
        // page to display information about the website
        public ActionResult About()
        {
            return View();
        }

        // page to link websites to assist user input
        public ActionResult BeforeYouStart()
        {
            return View();
        }
    }
}