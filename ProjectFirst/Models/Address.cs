using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFirst.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int AddressID { get; set; }

        public int? MunicipalityID { get; set; }

        [StringLength(50)]
        public string StreetAddress { get; set; }

        public virtual Municipality Municipality { get; set; }
    }
}
