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
                var ages = (from c in db.Cats select c.Age).Distinct().ToList();
                string jsonString = JsonConvert.SerializeObject(ages, Formatting.Indented);
                return new ContentResult
                {
                    Content = jsonString,
                    ContentType = "application/json",
                    ContentEncoding = System.Text.Encoding.UTF8
                };
            }
            else if (request == "breeds")
            {
                var breeds = (from b in db.Traits join bid in db.Breeds on b.BreedID equals bid.ID 
                              select new { Breeds = bid.CatBreed }).Distinct().ToList();

                string jsonString = JsonConvert.SerializeObject(breeds, Formatting.Indented);
                return new ContentResult
                {
                    Content = jsonString,
                    ContentType = "application/json",
                    ContentEncoding = System.Text.Encoding.UTF8
                };
            }
            else if (request == "colors")
            {
                var colors = (from c in db.Traits join cid in db.Colors on c.ColorID equals cid.ID
                              select new { Colors = cid.CatColor }).Distinct().ToList();

                string jsonString = JsonConvert.SerializeObject(colors, Formatting.Indented);
                return new ContentResult
                {
                    Content = jsonString,
                    ContentType = "application/json",
                    ContentEncoding = System.Text.Encoding.UTF8
                };

            }
            else if (request == "names")
            {
                var names = (from n in db.Cats select n.Name).Distinct().ToList();

                string jsonString = JsonConvert.SerializeObject(names, Formatting.Indented);
                return new ContentResult
                {
                    Content = jsonString,
                    ContentType = "application/json",
                    ContentEncoding = System.Text.Encoding.UTF8
                };
            }
            else
            {
                var personalities = (from p in db.PTags join pid in db.Personalities
                                     on p.FirstTrait equals pid.ID select new {Personalities = pid.Type}).ToList();
                var personalities2 = (from p in db.PTags join pid in db.Personalities
                                     on p.SecondTrait equals pid.ID select new {Personalities = pid.Type}).ToList();
                var personalities3 = (from p in db.PTags join pid in db.Personalities
                                     on p.ThirdTrait equals pid.ID select new {Personalities = pid.Type}).ToList();

                personalities = personalities.Concat(personalities2).Distinct().ToList();
                personalities = personalities.Concat(personalities3).Distinct().ToList();

                string jsonString = JsonConvert.SerializeObject(personalities, Formatting.Indented);
                return new ContentResult
                {
                    Content = jsonString,
                    ContentType = "application/json",
                    ContentEncoding = System.Text.Encoding.UTF8
                };
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