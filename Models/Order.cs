using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        
        public int PaymentTypeId { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer {get; set;}
            
        [DataType(DataType.Date)]
        public DateTime CompletedDate { get; set; }

    }
}