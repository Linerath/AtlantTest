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
        Detail GetDetailById(int detailId);
        DetailsModel GetAllDetailsData();
        void Add(Detail detail);
        void Update(Detail detail);
        void MarkDeleted(int detailId);
        void Delete(int detailId);
        void AddQuantity(int detailId, int quantity);
    }
}