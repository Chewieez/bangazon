using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(55)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(55)]
        public string LastName { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? CreationDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? LastLoginDate { get; set; }

        public virtual ICollection <Order> Orders { get; set; }
        public virtual ICollection <PaymentType> PaymentTypes { get; set; }
        public virtual ICollection <Product> Products { get; set; }

    }
}