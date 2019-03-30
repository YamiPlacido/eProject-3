using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eProject3.Models
{
    public class AboutUs
    {
        [Key]
        public int Aid { get; set; }

        [StringLength(500)] [Required]
        public string Aintroduction { get; set; }

        [StringLength(500)] [Required]
        public string Aservice { get; set; }
    }
}