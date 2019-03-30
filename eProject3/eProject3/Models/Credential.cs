using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eProject3.Models
{
    public class Credential
    {
        [Key]
        [Column(Order = 1)]
        public string UserGroupID { get; set; }

        [Key]
        [Column(Order = 2)]
        public string RoleID { get; set; }

        public virtual UserGroup UserGroup { get; set; }
        public virtual Role Role { get; set; }
    }
}