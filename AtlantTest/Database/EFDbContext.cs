using AtlantTest.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AtlantTest.Database
{
    public class EFDbContext : DbContext
    {
        public DbSet<Storekeeper> Storekeepers { get; set; }
        public DbSet<Detail> Details { get; set; }

        public EFDbContext()
            : base("name=DbConnection")
        { }
    }
}