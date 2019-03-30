using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eProject3.Models
{
    public class Student
    {
        [Key]
        public int StudentRoll { get; set; }
       
        [StringLength(50)] [Required]
        public string StudentFirstName { get; set; }

        [StringLength(50)] [Required]
        public string StudentLastName { get; set; }

        [StringLength(50)] [Required]
        public string StudentAddress { get; set; }

        [Required]
        public DateTime StudentDOB { get; set; }

        [StringLength(30)] [Required]
        public string StudentEmail { get; set; }

        [StringLength(4)] [Required]
        public string StudentResult { get; set; }

        public int ClassID { get; set; }
        public virtual Class Class { get; set; }
        public virtual ICollection<CourseStudent> CourseStudent { get; set; }
        public virtual ICollection<EntranceExamResult> EntranceExamResult { get; set; }
    }
}