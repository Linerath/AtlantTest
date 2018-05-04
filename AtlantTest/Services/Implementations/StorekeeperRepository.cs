using AtlantTest.Database;
using AtlantTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtlantTest.Services.Implementations
{
    public class StorekeeperRepository : IStorekeeperRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Storekeeper> GetAll()
        {
            return context.Storekeepers.AsQueryable();
        }
    }
}