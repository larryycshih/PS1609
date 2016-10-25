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
            //List<HomeFeedContainerViewModel> feedResult = new List<HomeFeedContainerViewModel>();
            HomeFeedContainerViewModel feeds = new HomeFeedContainerViewModel();

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

            // set the number of querys to get from the database. i recon 5 in enough
            int querysMax = 5;

            //sql taking the top x records
            var mostViewed = (from a in db.Research orderby a.views descending select a).Take(querysMax);
            var mostDownloaded = (from a in db.Research orderby a.downloads descending select a).Take(querysMax);
            var mostRecent = (from a in db.Research orderby a.publishedDate descending select a).Take(querysMax);

            //then add them into model
            List<HomeFeedMostDownloadedViewModel> ListMostDownloaded = new List<HomeFeedMostDownloadedViewModel>();
            List<HomeFeedMostRecentViewModel> ListMostRecent = new List<HomeFeedMostRecentViewModel>();
            List<HomeFeedMostViewedViewModel> ListMostViewed = new List<HomeFeedMostViewedViewModel>();
            List<HomeFeedTotalGrantsViewModel> ListTotalGrants = new List<HomeFeedTotalGrantsViewModel>();

            foreach (var item in mostDownloaded){
                ListMostDownloaded.Add(new HomeFeedMostDownloadedViewModel{id = item.ID,title = item.title,downloads = item.downloads,abstracts = item.abstracts});
            }
            foreach (var item in mostRecent){
                ListMostRecent.Add(new HomeFeedMostRecentViewModel { id = item.ID, title = item.title, publishedDate = item.publishedDate, abstracts = item.abstracts });
            }
            foreach (var item in mostViewed){
                ListMostViewed.Add(new HomeFeedMostViewedViewModel { id = item.ID, title = item.title, views = item.views, abstracts = item.abstracts });
            }




            // get the total grants from schools 
           var schools =  db.School;
            foreach (var item in schools)
            {
                var fgwrgf = (from a in db.Research where a.schoolID == item.ID select a.grants).Sum();
                ListTotalGrants.Add(new HomeFeedTotalGrantsViewModel { id = item.ID, schoolName = item.schoolName, totalGrants = Convert.ToInt32(fgwrgf) });
                
            }

            feeds.schoolCount = schoolResult;
            feeds.mostDownloadedFeed = ListMostDownloaded;
            feeds.mostRecentFeed = ListMostRecent;
            feeds.mostViewedFeed = ListMostViewed;
            feeds.totalGrants = ListTotalGrants;


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