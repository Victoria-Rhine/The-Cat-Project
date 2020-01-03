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
                var breeds = (from c in db.Cats
                              join bid in db.Breeds on c.BreedID equals bid.ID
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
                var colors = (from c in db.Cats
                              join cid in db.Colors on c.ColorID equals cid.ID
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
                var traits = (from c in db.Cats
                              join tid in db.Traits on c.TraitsID_1 equals tid.ID
                              select new { Traits = tid.Type }).Distinct().ToList();
                var traits2 = (from c in db.Cats
                               join tid in db.Traits on c.TraitsID_2 equals tid.ID
                               select new { Traits = tid.Type }).Distinct().ToList();
                var traits3 = (from c in db.Cats
                               join tid in db.Traits on c.TraitsID_3 equals tid.ID
                               select new { Traits = tid.Type }).Distinct().ToList();

                traits = traits.Concat(traits2).Distinct().ToList();
                traits = traits.Concat(traits3).Distinct().ToList();
                traits = traits.OrderBy(x => x.Traits).ToList();

                string jsonString = JsonConvert.SerializeObject(traits, Formatting.Indented);
                return new ContentResult
                {
                    Content = jsonString,
                    ContentType = "application/json",
                    ContentEncoding = System.Text.Encoding.UTF8
                };

            }
        }

        public ActionResult TopResults()
        {
            var topBreeds = db.Cats.Join(db.Breeds, c => c.BreedID, b => b.ID, (c, b) => new { c, b })
                .GroupBy(cb => cb.b.CatBreed).OrderByDescending(gp => gp.Count()).Take(5).Select(g => g.Key).ToList();
            ViewBag.TopBreeds = topBreeds;

            var topColors = db.Cats.Join(db.Colors, c => c.ColorID, cl => cl.ID, (c, cl) => new { c, cl })
                .GroupBy(ccl => ccl.cl.CatColor).OrderByDescending(gp => gp.Count()).Take(5).Select(g => g.Key).ToList();
            ViewBag.TopColors = topColors;

            var topNames = db.Cats.GroupBy(c => c.Name).OrderByDescending(gp => gp.Count()).Take(5).Select(g => g.Key).ToList();
            ViewBag.TopNames = topNames;

            var traits = (from p in db.Cats
                          join pid in db.Traits
                          on p.TraitsID_1 equals pid.ID
                          select new { Traits = pid.Type }).ToList();
            var traits2 = (from p in db.Cats
                           join pid in db.Traits
                           on p.TraitsID_2 equals pid.ID
                           select new { Traits = pid.Type }).ToList();
            var traits3 = (from p in db.Cats
                           join pid in db.Traits
                           on p.TraitsID_3 equals pid.ID
                           select new { Traits = pid.Type }).ToList();

            traits = traits.Concat(traits2).ToList();
            traits = traits.Concat(traits3).ToList();

            var topTraits = traits.GroupBy(p => p.Traits).OrderByDescending(gp => gp.Count()).Take(5).Select(g => g.Key).ToList();

            ViewBag.TopTraits = topTraits;
            return View();
        }

        public ActionResult Summary()
        {
            return View();
        }
    }
}
