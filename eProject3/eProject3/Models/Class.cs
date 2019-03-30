using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eProject3.Models
{
    public class Class
    {
        [Key]
        public int ClassID { get; set; }

        [StringLength(50)] [Required]
        public string ClassName { get; set; }

        [StringLength(500)] [Required]
        public string ClassDescription { get; set; }

        [Required]
        public decimal ClassTuitionFee { get; set; }

        [Required]
        public DateTime ClassPaymentDeadline { get; set; }

        [StringLength(50)] [Required]
        public string ClassEstimatedDuration { get; set; }

        [Required]
        public DateTime ClassStartDate { get; set; }

        [Required]
        public DateTime ClassEndDate { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}