using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
    public class OrderProduct
    {
        [Key]
        public int OrderProductId { get; set; }

        IEnumerable<OrderProduct> OrderProducts;
    }
}