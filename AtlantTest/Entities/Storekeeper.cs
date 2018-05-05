using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AtlantTest.Entities
{
    public class Storekeeper
    {
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Surname { get; set; }

        [Required]
        public String Patronymic { get; set; }
    }
}