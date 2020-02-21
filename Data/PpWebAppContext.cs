using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PPWebApp.Data
{
    public class PpWebAppContext : DbContext
    {

        public PpWebAppContext() : base("name=PpWebAppContext")
        {
        }

        public System.Data.Entity.DbSet<PPWebApp.Models.Furniture> Furniture { get; set; }

        public System.Data.Entity.DbSet<PPWebApp.Models.Category> Category { get; set; }
        public System.Data.Entity.DbSet<PPWebApp.Models.Booking> Booking { get; set; }

    }
}