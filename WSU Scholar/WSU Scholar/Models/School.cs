using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WSU_Scholar.Models
{
    public class School
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "School Name")]
        public string schoolName { get; set; }

        [StringLength(50)]
        [Display(Name = "Discipline Name")]
        public string disciplineName { get; set; }


    }

    public class SchoolCountViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "School Name")]
        public string schoolName { get; set; }

        public int count { get; set; }
    }

    public class SchoolDetailViewModel
    {

        public School school { get; set; }

        public IEnumerable<SchoolDetailContainer> details { get; set; }

    }

    public class SchoolDetailContainer
    {
        public int ID { get; set; }
        [Display(Name = "Title")]
        public String title { get; set; }
        [Display(Name = "Published Date")]
        public DateTime publishedDate { get; set; }
        [Display(Name = "Author")]
        public String authorName { get; set; }
    }



    public class HomeFeedContainerViewModel
    {
        public IEnumerable<SchoolCountViewModel> schoolCount { get; set; }
        public IEnumerable<HomeFeedMostRecentViewModel> mostRecentFeed { get; set; }
        public IEnumerable<HomeFeedMostViewedViewModel> mostViewedFeed { get; set; }
        public IEnumerable<HomeFeedMostDownloadedViewModel> mostDownloadedFeed { get; set; }
        public IEnumerable<HomeFeedTotalGrantsViewModel> totalGrants { get; set; }
    }

}