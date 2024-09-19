using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace miniProject.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public int Age { get; set; }

        public string Email { get; set; }
        public int ClassId { get; set; }
        public virtual Classes Class { get; set; }
    }
}