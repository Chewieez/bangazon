using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly BangazonAPIContext _context;

        public OrderController(BangazonAPIContext ctx)
        {
            _context = ctx;

            if (_context.Order.Count() == 0)
            {
                _context.SaveChanges();
            }
        }

        // GET api/order
        [HttpGet]
        public IActionResult Get()
        {

            var order = _context.Order.ToList();

            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);

        }

        // GET api/order/{id}
        [HttpGet("{id}", Name = "GetSingleOrderWithProducts")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                // Author: Dre Randaci
                // API GET request for a single order and all of it's associated products
                // Example respose:
                    // {
                    //     "orderId": 1,
                    //     "customerId": 1,
                    //     "paymentTypeId": 1,
                    //     "products": [
                    //     {
                    //         "productId": 1,
                    //         "name": "Knit Hat",
                    //         "price": 25,
                    //         "quantity": 2
                    //     },
                    //     {
                    //         "productId": 2,
                    //         "name": "Knit Scarf",
                    //         "price": 25,
                    //         "quantity": 4
                    //     }
                    // } 

                var order = 
                // Query for a single order
                _context.Order.Where(o => o.OrderId == id)
                // Create an anonymous object
                .Select(o => new {
                    OrderId = o.OrderId,
                    CustomerId = o.CustomerId,
                    PaymentTypeId = o.PaymentTypeId,
                    // Traverse the joiner table and return the products associated by creating another anonymous object
                    Products = o.OrderProducts.Select(op => new {
                        ProductId = op.Product.ProductId,
                        Name = op.Product.Name,
                        Price = op.Product.Price,
                        Quantity = op.Product.Quantity
                    }) 
                });                

                if (order == null)
                {
                    return NotFound();
                }

                return Ok(order);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Order.Add(order);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderExists(order.OrderId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleOrder", new { id = order.OrderId }, order);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Order.Update(order);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(order.OrderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleOrder", new { id = order.OrderId }, order);


        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Order order = _context.Order.Single(t => t.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }
            _context.Order.Remove(order);
            _context.SaveChanges();
            return Ok(order);
        }

        private bool OrderExists(int orderId)
        {
            return _context.Order.Any(g => g.OrderId == orderId);
        }
    }
}
