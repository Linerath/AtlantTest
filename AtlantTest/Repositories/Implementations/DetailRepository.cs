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

        public void Add(Detail detail)
        {
            context.Details.Add(detail);
            context.SaveChanges();
        }

        public void Delete(int detailId)
        {
            var detail = context.Details.FirstOrDefault(x => x.Id == detailId);
            if (detail != null)
            {
                context.Details.Remove(detail);
                context.SaveChanges();
            }
        }

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