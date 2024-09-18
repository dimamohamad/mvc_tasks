using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _18_9_2024.Models
{



public class Student
    {
        [Key]  
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }


        [ForeignKey("StudentDetails")]
        public int StudentDetailsId { get; set; }
        public virtual StudentDetails StudentDetails { get; set; }
    }
}
