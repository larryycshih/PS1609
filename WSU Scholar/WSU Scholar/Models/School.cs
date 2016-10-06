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
}