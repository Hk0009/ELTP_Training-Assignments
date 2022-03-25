using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment_08_03_2022.Models
{
    public class Course
    {
        [Key] // Identity Primary Key
        public int CourseId { get; set; }
        [Required]
        [StringLength(20)]
        public string CourseName { get; set; }
        [Required]
        [StringLength(200)]
        public string CourseDuration { get; set; }
        [Required]
        public int Fees { get; set; }
        [Required]
        [StringLength(200)]
        public string CourseType { get; set; }


        public ICollection<Student> Students { get; set; } // One-To-Many
    }
}
