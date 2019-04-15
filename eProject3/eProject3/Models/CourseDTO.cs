using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eProject3.Models
{
    public class CourseDTO
    {
        [Key]
        public int CourseID { get; set; }

        [StringLength(50)]
        [Required]
        public string CourseName { get; set; }

        [StringLength(500)]
        [Required]
        public string CourseDesctiption { get; set; }

        [StringLength(50)]
        [Required]
        public string CourseDuration { get; set; }

        [Required]
        public string CourseStartDate { get; set; }

        [Required]
        public string CourseEndDate { get; set; }

        [Required]
        public string CourseImage { get; set; }

        public virtual ICollection<CourseStudent> CourseStudent { get; set; }
    }
}