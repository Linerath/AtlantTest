using AtlantTest.Database;
using AtlantTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtlantTest.Repositories.Implementations
{
    public class StorekeeperRepository : IStorekeeperRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Storekeeper> GetAll()
        {
            return context.Storekeepers.AsQueryable();
        }

        public void Add(Storekeeper storekeeper)
        {
            context.Storekeepers.Add(storekeeper);
        }
    }
}