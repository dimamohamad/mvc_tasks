using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace miniProject.Models
{
    public class Classes
    {
        [Key]
        public int ClassId { get; set; }
        [Required]
        public string ClassName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
        public Classes()
        {
            Students = new List<Student>();
            Tasks = new List<Tasks>();
        }

    }
}