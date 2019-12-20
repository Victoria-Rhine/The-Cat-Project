using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheCatProject.Controllers
{
    public class InformationController : Controller
    {
        // GET: Information
        public ActionResult Index()
        {
            return View();
        }

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