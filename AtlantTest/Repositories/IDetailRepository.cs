using AtlantTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlantTest.Repositories
{
    public interface IDetailRepository
    {
        IQueryable<Detail> GetAll();
        IQueryable<Detail> GetByStorekeeperId(int storekeeperId);
        void Add(Detail detail);
        void Update(Detail detail);
        void MarkDeleted(int detailId);
        void Delete(int detailId);
    }
}
