using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AtlantTest.Database;
using AtlantTest.Entities;

namespace AtlantTest.Repositories.Implementations
{
    public class DetailRepository : IDetailRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Detail> GetAll()
        {
            return context.Details.AsQueryable();
        }

        public Detail GetByStorekeeperId(int storekeeperId)
        {
            return context.Details.FirstOrDefault(x => x.StorekeeperId == storekeeperId);
        }
    }
}