using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace miniProject.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TaskDescription { get; set; }
        [Required]
        public DateTime subDate { get; set; }
        public int ClassId { get; set; }
        public virtual Classes Class { get; set; }
    }
}