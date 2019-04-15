using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eProject3.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(500)]
        [Column(TypeName = "VARCHAR")]
        public string CourseDescription { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string CourseDuration { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public DateTime CourseStartDate { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public DateTime CourseEndDate { get; set; }

        public string CourseImage { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public virtual ICollection<CourseStudent> CourseStudent { get; set; }
    }
}