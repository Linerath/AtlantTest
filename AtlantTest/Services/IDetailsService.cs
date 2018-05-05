using AtlantTest.Entities;
using AtlantTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtlantTest.Services
{
    public interface IDetailsService
    {
        IEnumerable<Detail> GetAllDetails();
        IEnumerable<DetailModel> GetAllDetailsData();
    }
}