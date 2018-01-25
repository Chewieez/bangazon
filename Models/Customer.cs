using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
    public class Customer
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(55)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(55)]
        public string LastName { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime LastLoginDate { get; set; }

        IEnumerable <Order> Orders;
        IEnumerable <PaymentType> PaymentTypes;
        IEnumerable <Product> Products;

    }
}