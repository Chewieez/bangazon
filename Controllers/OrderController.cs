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

        // GET api/single order with products
        [HttpGet("{id}", Name = "GetSingleOrderWithProducts")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // var order = _context.Order.Where(o => o.OrderId == id)

                var productList = _context
                .OrderProduct
                .Where(o => o.OrderId == id)
                .Select(o => o.Product).ToList();
                // .Select(o => o.Product).ToList();

                // foreach (var p in productList)
                // {
                //     Console.WriteLine(p.Name);
                //     Console.WriteLine(p.Price);
                //     Console.WriteLine(p.Quantity);
                //     Console.WriteLine(p.ProductId);
                // }
                // .Select(o => o.Product);
                

                var order = _context
                .Order
                .Where(o => o.OrderId == id)
                .Include("OrderProduct.Product")
                .Select(o => new Order()
                {
                    OrderId = o.OrderId,
                    CustomerId = o.CustomerId,
                    PaymentTypeId = o.PaymentTypeId,
                    OrderProducts = productList
                });                
                // .Include("Order");
                // .Select(o =>o new Order(){
                //     OrderId = id,
                //     PaymentTypeId = o.PaymentTypeId,
                //     CustomerId = o.CustomerId,
                //     CompletedDate = o.CompletedDate
                //     // OrderProducts = o.Product
                // });                         

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
