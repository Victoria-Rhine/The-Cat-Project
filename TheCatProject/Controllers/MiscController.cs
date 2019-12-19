using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheCatProject.Controllers
{
    public class MiscController : Controller
    {
        // GET: Misc
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BreedInfo()
        {
            return View();
        }
    }
}