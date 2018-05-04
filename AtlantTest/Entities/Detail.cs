using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtlantTest.Entities
{
    public class Detail
    {
        public int Id { get; set; }
        public String NomenclatureCode { get; set; }
        public String Name { get; set; }
        public int Quantity { get; set; }
        public int StorekeeperId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}