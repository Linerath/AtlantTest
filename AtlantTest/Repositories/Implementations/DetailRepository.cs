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

        public void Update(Detail detail)
        {
            context.Entry(detail).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void MarkDeleted(int detailId)
        {
            var detail = context.Details.FirstOrDefault(x => x.Id == detailId);
            if (detail != null)
            {
                detail.DeleteDate = DateTime.Now;
                detail.Quantity = 0;
                Update(detail);
            }
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

        public IQueryable<Detail> GetByStorekeeperId(int storekeeperId)
        {
            return context.Details.Where(x => x.StorekeeperId == storekeeperId);
        }
    }
}