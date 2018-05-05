using AtlantTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlantTest.Repositories
{
    public interface IStorekeeperRepository
    {
        IQueryable<Storekeeper> GetAll();
        Storekeeper Get(int Id);
        void Add(Storekeeper storekeeper);
    }
}
