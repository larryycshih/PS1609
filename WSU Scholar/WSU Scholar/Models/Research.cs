using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WSU_Scholar.Models
{
    public class Research
    {
        public int ID { get; set; }

        [Required]
        [Display(Name="Title")]
        public string title { get; set; }

        [Required]
        public int schoolID { get; set; }

        [DataType(DataType.Date)]
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

        [Display(Name = "Abstract")]
        public string abstracts { get; set; }

        public virtual Record Record { get; set; }
        public virtual ICollection<ResearchAuthor> ResearchAuthor { get; set; }
        public virtual School School { get; set; }
    }
}