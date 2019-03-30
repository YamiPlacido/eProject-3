using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eProject3.Models
{
    public class FAQ
    {
        [Key]
        public int Fid { get; set; }
        
        [StringLength(500)] [Required]
        public string Fquestion { get; set; }

        [StringLength(500)] [Required]
        public string Fanswer { get; set; }
    }
}