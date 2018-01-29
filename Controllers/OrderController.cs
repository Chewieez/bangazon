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

        // GET api/orders
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

        // GET api/orders/{id}
        [HttpGet("{id}", Name = "GetSingleOrderWithProducts")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var order = _context.Order.Single(o => o.OrderId == id);                
                var products = _context.Product.Where(p => _context.OrderProduct.Where(op => op.OrderId == id).Any(prod => p.ProductId == prod.ProductId)).Select(p => new {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity
                });    

                if (order == null)
                {
                    return NotFound();
                }

                return Ok(
                    new {
                        OrderId = id,
                        CustomerId = order.CustomerId,
                        PaymentTypeId = order.PaymentTypeId,
                        Products = products
                    }
                );
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
