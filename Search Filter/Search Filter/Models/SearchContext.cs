using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Search_Filter.Models
{
    public class SearchContext:DbContext
    {
        public DbSet<Search> Searchs { get; set; }
    }
}