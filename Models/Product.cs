using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        
        [Required]
        public int ProductCategoryId {get; set;}
        public ProductCategory ProductCategory {get; set;}

        [Required]
        public int CustomerId {get; set;}



        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public int Quantity { get; set; }


    }
}