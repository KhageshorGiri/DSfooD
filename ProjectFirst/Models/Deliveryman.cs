using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFirst.Models
{
    [Table("Deliveryman")]
    public class Deliveryman
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Deliveryman()
        {
            DeliveryInformations = new HashSet<DeliveryInformation>();
        }

        [Key]
        public int DeliverymansID { get; set; }

        public string DeliverymanName { get; set; }

        public string Address { get; set; }

        public string PhoneNo { get; set; }

        public string CitizenshipNo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryInformation> DeliveryInformations { get; set; }
    }
}
