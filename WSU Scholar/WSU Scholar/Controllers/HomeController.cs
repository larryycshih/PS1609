using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSU_Scholar.Models;

namespace WSU_Scholar.Controllers
{
    public class HomeController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        public ActionResult Index()
        {
            Dictionary<String,int> list = new Dictionary<string,int>();

            
            //var data = db.Research.GroupBy(x => x.schoolID).Select(g => new {g.Key, Count = g.Count()});

            var Counts =
                from p in db.Research
                group p by p.schoolID into g
                select new { Category = g.Key, ProductCount = g.Count() };

            //got this from here
            //http://stackoverflow.com/questions/695506/linq-left-join-group-by-and-count
            var data =
                from p in db.School
                join c in db.Research on p.ID equals c.schoolID into j1
                from j2 in j1.DefaultIfEmpty()
                group j2 by p.schoolName into grouped 
                select new { Key = grouped.Key, Count = grouped.Count(t => t.ID != null) };

            ViewData["ShoolsCount"] = data.ToList();
            List<SchoolCountViewModel> result = new List<SchoolCountViewModel>();
            foreach (var item in data)
            {
                result.Add(new SchoolCountViewModel { schoolName = item.Key, count = item.Count });
            }

            //return View(db.School.ToList());
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }


}