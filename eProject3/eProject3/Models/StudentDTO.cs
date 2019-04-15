using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eProject3.Models
{
    public class StudentDTO
    {
        [Key]
        public int StudentRoll { get; set; }

        [StringLength(50)]
        [Required]
        public string StudentFirstName { get; set; }

        [StringLength(50)]
        [Required]
        public string StudentLastName { get; set; }

        [StringLength(50)]
        [Required]
        public string StudentAddress { get; set; }

        [Required]
        public string StudentDOB { get; set; }

        [StringLength(30)]
        [Required]
        public string StudentEmail { get; set; }

        [StringLength(4)]
        [Required]
        public string StudentResult { get; set; }

        public int ClassID { get; set; }
    }
}