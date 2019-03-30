using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eProject3.Models
{
    public class Role
    {
        [Key]
        public string RoleID { get; set; }

        [Required]
        public string RoleDetail { get; set; }

        public virtual ICollection<Credential> Credential { get; set; }
    }
}