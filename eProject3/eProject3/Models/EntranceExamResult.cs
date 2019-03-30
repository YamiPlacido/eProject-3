using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eProject3.Models
{
    public class EntranceExamResult
    {
        [Key]
        [Column(Order =1)]
        public int StudentRoll { get; set; }

        [Key]
        [Column(Order = 2)]
        public int EntranceExamID { get; set; }

        [Required]
        public decimal Mark { get; set; }

        public virtual EntranceExam EntranceExam { get; set; }
        public virtual Student Student { get; set; }
    }
}