using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Code_First_Approah.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int EmpId { get; set; }

        [Required]
        public string EmpName { get; set; }

        [Required]
        public string EmpDesignation { get; set; }

        [Required]
        public int EmpPhone { get; set; }

        [Required]
        public string EmpEmail { get; set; }

        [Required]
        public string EmpAddress { get; set; }
    }
}