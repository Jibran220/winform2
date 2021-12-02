using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cookiess.Models
{
    public class user
    {
        [Required]
        public string name { get; set; }
    }
}