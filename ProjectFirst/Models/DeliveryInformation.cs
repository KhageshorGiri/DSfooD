using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFirst.Models
{
    [Table("DeliveryInformation")]
    public class DeliveryInformation
    {
        [Key]
        public int DeliveryInformationID { get; set; }

        public int? ClientID { get; set; }

        public int? DeliverymansID { get; set; }

        public string Signature { get; set; }

        public virtual Deliveryman Deliveryman { get; set; }

        public virtual Client Client { get; set; }
    }
}
