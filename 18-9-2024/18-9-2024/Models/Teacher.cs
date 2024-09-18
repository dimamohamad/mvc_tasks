using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace _18_9_2024.Models
{
    public class Teacher
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("Name")]
        public string TeacherName { get; set; }

        [Required]
        public int age { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}