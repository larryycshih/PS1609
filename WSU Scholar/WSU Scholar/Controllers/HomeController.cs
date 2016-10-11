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
            List<SchoolCountViewModel> schoolResult = new List<SchoolCountViewModel>();
            List<HomeFeedViewModel> feedResult = new List<HomeFeedViewModel>();
            HomeModelContainerViewModel feeds = new HomeModelContainerViewModel();

            //got this from here
            //http://stackoverflow.com/questions/695506/linq-left-join-group-by-and-count

            // query the 'research' database and count each occurances of school names.
            var data1 =
                from p in db.School
                join c in db.Research on p.ID equals c.schoolID into j1
                from j2 in j1.DefaultIfEmpty()
                group j2 by p.schoolName into grouped
                select new { Key = grouped.Key, Count = grouped.Count(t => t.ID != null) };
            // and then sort them into list to pass on to view     
            foreach (var item in data1)
            {
                schoolResult.Add(new SchoolCountViewModel
                {
                    schoolName = item.Key,
                    count = item.Count
                });
            }

            //potentially very laggy for large database
            foreach (var item in db.Research.ToList())
            {
                feedResult.Add(new HomeFeedViewModel
                {
                    title = item.title,
                    publishedDate = item.publishedDate,
                    views = item.views,
                    downloads = item.downloads,
                    abstracts = item.abstracts
                });
            }



            feeds.schoolCount = schoolResult;
            feeds.homeFeed = feedResult;

            return View(feeds);
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