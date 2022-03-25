using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment_08_03_2022.Models
{
    public class Student
    {
        [Key] // Identity Primary Key
        public int StudentId { get; set; }
        [Required]
        [StringLength(30)]
        public string StudentUniqueId { get; set; }
        [Required]
        [StringLength(300)]
        public string StudentName { get; set; }
        [Required]
        public int CourseId { get; set; } // Expected to be a Foreign Key
        [Required]
        public int CourseYear { get; set; }
        [Required]
        [StringLength(300)]
        public string FeeStatus { get; set; } 
        public Course Course { get; set; } // REferential Integrity One-to-One

    }
}
