using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication18.Models
{
    public class Assignment
    {
        [Key]
        public int ID { get; set; }

       
        public string AsignmentName { get; set; }

        public DateTime ? date { get; set; }
    }
}