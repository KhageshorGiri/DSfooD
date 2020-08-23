using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFirst.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public int? ClientID { get; set; }

        public int? ProductID { get; set; }
        public int? paymentId { get; set; }

        public string DeliveryTime { get; set; }

        public virtual Client Client { get; set; }
        public virtual Payment Payment { get; set; }


        public virtual Product Product { get; set; }
    }
}
