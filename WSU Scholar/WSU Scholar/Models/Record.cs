using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WSU_Scholar.Models
{
    public class Record
    {
        [Key]
        [ForeignKey("Research")]
        public int researchID { get; set; }
        
        public string fileID { get; set; }

        public virtual Research Research { get; set; }
    }
}