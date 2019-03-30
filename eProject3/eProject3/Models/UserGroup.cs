using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eProject3.Models
{
    public class UserGroup
    {
        [Key]
        public string UserGroupID { get; set; }

        [Required]
        public string UserGroupName { get; set; }

        public virtual ICollection<Credential> Credential { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}