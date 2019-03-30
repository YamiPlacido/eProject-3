using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eProject3.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
       
        [StringLength(20,ErrorMessage ="Username cannot be longer than 20 chars")]
        [Required]
        public string UserName { get; set; }

        [StringLength(20,ErrorMessage = "Password cannot be longer than 20 chars")]
        [Required]
        public string UserPassword { get; set; }

        [StringLength(20,ErrorMessage = "First Name cannot be longer than 20 chars")]
        [Required]
        public string UserFirstName { get; set; }

        [StringLength(20, ErrorMessage = "Last Name cannot be longer than 20 chars")]
        [Required]
        public string UserLastName { get; set; }

        [StringLength(50, ErrorMessage = "Address cannot be longer than 50 chars")]
        [Required]
        public string UserAddress { get; set; }

        [Required]
        public DateTime UserDOB { get; set; }

        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 chars")]
        [Required]
        public string UserEmail { get; set; }

        public string GroupID { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}