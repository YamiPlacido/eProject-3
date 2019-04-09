using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eProject3.Models
{
    public class EntranceExamDTO
    {
        [Key]
        public int EntranceExamID { get; set; }

        [StringLength(50)]
        [Required]
        public string EntranceExamName { get; set; }

        [StringLength(500)]
        [Required]
        public string EntranceExamDescription { get; set; }

        [Required]
        public string EntranceExamStartDate { get; set; }
    }
}