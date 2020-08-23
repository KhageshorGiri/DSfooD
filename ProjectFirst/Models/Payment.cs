using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFirst.Models
{
    [Table("Payment")]
    public class Payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Payment()
        {

            Orders = new HashSet<Order>();
        }

        [Key]
        public int PaymentID { get; set; }

        public int? OrderID { get; set; }

        public int? ClientID { get; set; }

        public string CoupenCode { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? PayedAmount { get; set; }


        public string Date { get; set; }

        public string Code { get; set; }

        public virtual Client Client { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
