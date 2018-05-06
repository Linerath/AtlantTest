using AtlantTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtlantTest.Models
{
    public class DetailsModel
    {
        public IEnumerable<DetailModel> DetailsData { get; set; }
        public IEnumerable<Storekeeper> Storekeepers { get; set; }
    }
}