using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WSU_Scholar.Models
{
    public enum Title
    {
        Mr, Ms,  Mrs, Miss, Master, Dr, Prof
    }
   
    public class Author
    {
        public int ID { get; set; }
        public Title? title { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string fname { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string lname { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            { return fname + lname; }
        }


        public int schoolID { get; set; }

        public int telephone { get; set; }

        public string email { get; set; }

        public int mobile { get; set; }

        public string university { get; set; }

        public string campus { get; set; }

    
        public virtual School School { get; set; }

    }
}