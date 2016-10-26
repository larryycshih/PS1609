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
       [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        
        public int researchID { get; set; }
        
        public int authorID { get; set; }

        public virtual Author Author { get; set; }
        public virtual Research Research { get; set; }

    }
}
