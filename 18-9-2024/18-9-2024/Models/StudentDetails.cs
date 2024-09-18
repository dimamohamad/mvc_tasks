using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _18_9_2024.Models
{
    public class StudentDetails
    {
        [Key]
        public int StudentDetailID { get; set; }

      
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Student Student { get; set; }
    }
}
