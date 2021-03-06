﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WSU_Scholar.Models
{
    public class Research
    {
        public int ID { get; set; }

        [Required]
        [Display(Name="Title")]
        public string title { get; set; }

        [Required]
        [Display(Name="School")]
        public int schoolID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
        [Display(Name="Published Date")]
        public DateTime publishedDate { get; set; }
        
        [Display(Name = "Subject")]
        public string subject { get; set; }

        [Display(Name = "Grants")]
        public Decimal grants { get; set; }

        [Display(Name = "Views")]
        public int views { get; set; }

        [Display(Name = "Downloads")]
        public int downloads { get; set; }

        //[AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Abstract")]
        public string abstracts { get; set; }

        public virtual Record Record { get; set; }
        public virtual School School { get; set; }
    }

    public class HomeFeedMostRecentViewModel{
        public int id { get; set; }

        public string title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime publishedDate { get; set; }

        public string abstracts { get; set; }
    }

    public class HomeFeedMostViewedViewModel
    {
        public int id { get; set; }
        public string title { get; set; }

        public int views { get; set; }

        public string abstracts { get; set; }
    }

    public class HomeFeedMostDownloadedViewModel
    {
        public int id { get; set; }
        public string title { get; set; }

        public int downloads { get; set; }

        public string abstracts { get; set; }
    }

    public class HomeFeedTotalGrantsViewModel
    {
        public int id { get; set; }
        public string schoolName { get; set; }

        public int totalGrants { get; set; }

    }

    public class ResearchCreateViewModel
    {
        public Research research { get; set; }

        public IEnumerable<AuthorList> authors { get; set; }
    }

    public class ResearchDetailsViewModel
    {
        public Research research { get; set; }
        public Author author { get; set; }
    }
}