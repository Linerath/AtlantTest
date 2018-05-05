using AtlantTest.Entities;
using AtlantTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlantTest.Services
{
    public interface IStorekeepersService
    {
        IEnumerable<Storekeeper> GetAllStorekeepers();
        IEnumerable<StorekeepersModel> GetAllStorekeepersData();
    }
}