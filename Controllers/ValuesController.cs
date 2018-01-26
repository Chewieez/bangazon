using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private readonly BangazonAPIContext _context;

        // GET api/Orders
        public IEnumerable<OrdersDto> GetOrdersAndProducts()
        {
            var orders = _context
                .Order
                .Include("Product")
                .Select(o => new OrdersDto
                {
                    OrderId = o.OrderId,
                    CustomerId = o.CustomerId,
                    PaymentTypeId = o.PaymentTypeId,
                    OrderProducts = _context.Product.Select(p => new ProductDto
                    {
                        ProductId = p.ProductId,
                        Price = p.Price,
                        Quantity = p.Quantity,
                        Name = p.Name
                    })
                }).ToList();

            return orders;
        }
    }
    public class OrdersDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int? PaymentTypeId { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductDto> OrderProducts { get; set; }
    }

    public class ProductDto
    {
        public int ProductId { get; set; }

        public double Price { get; set; }
                    
        public int Quantity { get; set; }

        public string Name { get; set; }
    }
}