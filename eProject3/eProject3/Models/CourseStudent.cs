using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eProject3.Models
{
    public class CourseStudent
    {
        [Key]
        [Column(Order = 1)]
        public int CourseID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int StudentRoll { get; set; }

        [Required]
        public decimal LabFee { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}