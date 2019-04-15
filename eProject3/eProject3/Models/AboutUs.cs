using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eProject3.Models
{
    public class AboutUs
    {
        [Key]
        public int Aid { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(500)]
        [Column(TypeName = "VARCHAR")]
        public string Aintroduction { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(500)]
        [Column(TypeName = "VARCHAR")]
        public string Aservice { get; set; }
    }
}