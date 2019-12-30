using Newtonsoft.Json;
using System.Data;
using System.Data.Entity;
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

        public ActionResult StatsQuery()
        {
            string request = Request.QueryString["selection"];

            if (request == "ages")
            {
                var ages = (from c in db.Cats select c.Age).ToList();
                string jsonString = JsonConvert.SerializeObject(ages, Formatting.Indented);
                return new ContentResult
                {
                    Content = jsonString,
                    ContentType = "application/json",
                    ContentEncoding = System.Text.Encoding.UTF8
                };
            }
            else if (request == "names")
            {
                var names = (from n in db.Cats select n.Name).ToList();
                string jsonString = JsonConvert.SerializeObject(names, Formatting.Indented);
                return new ContentResult
                {
                    Content = jsonString,
                    ContentType = "application/json",
                    ContentEncoding = System.Text.Encoding.UTF8
                };
            }
            else if (request == "breeds")
            {
                var traits = db.Traits.Include(t => t.Breed).ToList();
                // need to fix how json is working here with connected db tables
                string jsonString = JsonConvert.SerializeObject(traits, Formatting.Indented);
                return new ContentResult
                {
                    Content = jsonString,
                    ContentType = "application/json",
                    ContentEncoding = System.Text.Encoding.UTF8
                };
            }


            else
            {
                return View();
            }
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