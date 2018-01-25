using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }

        [Required]
        [StringLength(55)]
        public string Name { get; set; }

        [Required]
        public int AccountNumber { get; set; }
        IEnumerable<PaymentType> PaymentTypes;
    }
}