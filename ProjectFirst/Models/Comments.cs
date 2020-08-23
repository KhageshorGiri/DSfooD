using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFirst.Models
{
    [Table("Comments")]
    public class Comments
    {
        [Key]
        public int CommentID { get; set; }

        public int? ClientID { get; set; }

        public string Comment1 { get; set; }

        public string Rating { get; set; }

        public virtual Client Client { get; set; }
    }
}
