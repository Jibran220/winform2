using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;


namespace Cookies_remember.Models
{
    public class cookiesContext:DbContext
    {
        public DbSet<COOKIES> COOKIESs { get; set; }
    }
}