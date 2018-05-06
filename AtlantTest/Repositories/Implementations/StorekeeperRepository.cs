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

        public Storekeeper Get(int Id)
        {
            return context.Storekeepers.FirstOrDefault(x => x.Id == Id);
        }

        public void Add(Storekeeper storekeeper)
        {
            context.Storekeepers.Add(storekeeper);
            context.SaveChanges();
        }

        public void Delete(int storekeeperId)
        {
            var storekeeper = context.Storekeepers.FirstOrDefault(x => x.Id == storekeeperId);
            if (storekeeper != null)
            {
                context.Storekeepers.Remove(storekeeper);
                context.SaveChanges();
            }
        }
    }
}