using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cookies_remember.Models
{
    public class COOKIES
    {
        [Key]
        [Required]
        public int userid { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string userpassword { get; set; }


        public bool Remember { get; set; }
    }
}