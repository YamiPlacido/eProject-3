using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eProject3.Models
{
    public class ClassDTO
    {
        [Key]
        public int ClassID { get; set; }

        [StringLength(50)]
        [Required]
        public string ClassName { get; set; }

        [StringLength(500)]
        [Required]
        public string ClassDescription { get; set; }

        [Required]
        public decimal ClassTuitionFee { get; set; }

        [Required]
        public string ClassPaymentDeadline { get; set; }

        [StringLength(50)]
        [Required]
        public string ClassEstimatedDuration { get; set; }

        [Required]
        public string ClassStartDate { get; set; }

        [Required]
        public string ClassEndDate { get; set; }
    }
}