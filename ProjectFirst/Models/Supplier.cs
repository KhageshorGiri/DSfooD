using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFirst.Models
{
    [Table("Supplier")]
    public class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            SupplierAttributes = new HashSet<SupplierAttribute>();
        }

        [Key]
        public int SuppliersID { get; set; }

        public string SuppliersName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierAttribute> SupplierAttributes { get; set; }
    }
}
