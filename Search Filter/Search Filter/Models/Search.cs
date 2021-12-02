using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Search_Filter.Models
{
    public class Search
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public int   age { get; set; }
    }
}