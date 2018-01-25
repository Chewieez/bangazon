using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }

        [Required]
        [StringLength(55)]
        public string Name { get; set; }

        IEnumerable<Product> Products;
        
        
    }
}