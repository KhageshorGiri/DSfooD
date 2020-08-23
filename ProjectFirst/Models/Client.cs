using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFirst.Models
{
    [Table("Client")]
    public class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Comment = new HashSet<Comments>();
            Orders = new HashSet<Order>();
            Payments = new HashSet<Payment>();
            DeliveryInformations = new HashSet<DeliveryInformation>();
        }
        [Key]
        public int ClientID { get; set; }

        public string ClientName { get; set; }

        public int? AddressID { get; set; }

        public int? PermanentAddressID { get; set; }

        public int? TemporaryAddressID { get; set; }

        public string PhoneNo { get; set; }

        public string Location { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Image { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }

        public string Code { get; set; }

        public string RefferClientCode { get; set; }
        public int CartID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryInformation> DeliveryInformations { get; set; }
    }
}
