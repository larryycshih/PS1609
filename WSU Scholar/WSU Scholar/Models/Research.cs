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
        public string title { get; set; }

        [Required]
        public int schoolID { get; set; }

        [DataType(DataType.Date)]
        public DateTime publishedDate { get; set; }

        public string subject { get; set; }

        public Decimal grants { get; set; }

        public int views { get; set; }

        public int downloads { get; set; }

        public string abstracts { get; set; }

        public virtual Record Record { get; set; }
        public virtual ICollection<ResearchAuthor> ResearchAuthor { get; set; }
        public virtual School School { get; set; }
    }
}