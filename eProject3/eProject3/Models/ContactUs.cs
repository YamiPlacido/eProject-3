using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eProject3.Models
{
    public class ContactUs
    {
        [Key]
        public int Cid { get; set; }

        [Required]
        [StringLength(2000)]
        [Column(TypeName = "VARCHAR")]
        public string Clocation { get; set; }

        [Required]
        [StringLength(1000)]
        [Column(TypeName = "VARCHAR")]
        public string Caddress { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        [Required]
        [StringLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string Cemail { get; set; }
    }
}