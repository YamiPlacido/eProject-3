using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eProject3.Models
{
    public class ContactUs
    {
        [Key]
        public int Cid { get; set; }

        [StringLength(200)] [Required]
        public string Clocation { get; set; }

        [StringLength(200)] [Required]
        public string Caddress { get; set; }

        [StringLength(100)] [Required]
        public string Cemail { get; set; }
    }
}