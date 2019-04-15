using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eProject3.Models
{
    public class FAQ
    {
        [Key]
        public int Fid { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(500)]
        [Column(TypeName = "VARCHAR")]
        public string Fquestion { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(500)]
        [Column(TypeName = "VARCHAR")]
        public string Fanswer { get; set; }
    }
}