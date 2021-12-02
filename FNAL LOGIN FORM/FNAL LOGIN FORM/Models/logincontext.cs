using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FNAL_LOGIN_FORM.Models
{
    public class logincontext:DbContext
    {
        public DbSet<LOGIN> LOGINS { get; set; }
    }
}