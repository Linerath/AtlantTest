using AtlantTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlantTest.Services
{
    public interface IStorekeeperRepository
    {
        IQueryable<Storekeeper> GetAll();
    }
}
