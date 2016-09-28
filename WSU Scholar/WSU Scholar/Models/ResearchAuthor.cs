using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WSU_Scholar.Models
{
    public class ResearchAuthor
    {

        public int ID { get; set; }

        //[Key]
        //[ForeignKey("Research")]
        public int researchID { get; set; }

        //[Key]
        //[ForeignKey("Author")]
        public int authorID { get; set; }

        public virtual ICollection<Author> Author { get; set; }
        public virtual ICollection<Research> Research { get; set; }

    }
}