using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    [Table("Customers")] 
    public class Customer
    {
      
        [Key]
        [StringLength(50, ErrorMessage = "Username must have less than 50 character")]
        [Column("Username")]
        public string username { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Password must have less than 500 character")]
        [Column("Password")]
        public string password { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Fullname must have less than 50 character")]
        [Column("Fullname")]
        public string fullname { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Gender must have less than 50 character")]
        [Column("Gender")]
        public string gender { get; set; }
        [Required]
        [Column("Birthday", TypeName = "date")]
        public DateTime birthday { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Username must have less than 500 character")]
        [Column("Address", TypeName = "text"),]
        public string address { get; set; }
    }
}
