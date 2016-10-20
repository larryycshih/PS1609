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

        [Range(0000000000, 9999999999)]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        public int telephone { get; set; }

        [Display(Name="Email")]
        [Required(ErrorMessage="This field is required")]
        [EmailAddress(ErrorMessage="Invalid Email Address")]
        public string email { get; set; }

        [Range(0000000000,9999999999)]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        public int mobile { get; set; }

        [Display(Name="University")]
        public string university { get; set; }

        [Display(Name="Campus")]
        public string campus { get; set; }
            
        public virtual School School { get; set; }

    }

    public class AuthorList
    {
        public int ID { get; set; }
        public String fullName { get; set; }
    }

    public class AuthorDetailViewModel
    {
        public Author author { get; set; }
        public IEnumerable<Research> research { get; set; }

    }

}