
namespace Research_Portal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Record
    {
        [Required]
        public int recordID { get; set; }
        public int researchID { get; set; }
        public string fileID { get; set; }
    
        public virtual Research Research { get; set; }
    }
}
