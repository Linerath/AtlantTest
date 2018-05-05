using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AtlantTest.Entities
{
    public class Detail
    {
        public int Id { get; set; }

        [Required]
        public String NomenclatureCode { get; set; }

        [Required]
        public String Name { get; set; }

        public int Quantity { get; set; }

        [Required]
        public int StorekeeperId { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public DateTime? DeleteDate { get; set; }
    }
}