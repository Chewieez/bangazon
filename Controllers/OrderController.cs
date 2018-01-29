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
        }

        /*
            Author: Jason Figueroa
            URL: GET api/order
            Description:
            Returns the order values from the database
            Example GET response:
            [
                {
                    "orderId": 1,
                    "paymentTypeId": 1,
                    "customerId": 1,
                    "customer": null,
                    "completedDate": "2017-07-17T00:00:00"
                },
                {
                    "orderId": 2,
                    "paymentTypeId": 16,
                    "customerId": 16,
                    "customer": null,
                    "completedDate": "2017-12-09T00:00:00"
                }
            ]
        */
        [HttpGet]
        public IActionResult Get()
        {
            // from the BangazonAPIContext object, retrieve the Order table
            var order = _context.Order.ToList();

            if (order == null)
            {
                return NotFound();
            }

            // values will be in JSON format
            return Ok(order);

        }

        /*
            Author: Jason Figueroa
            URL: GET api/order/{id}
            Description:
            Returns a specific order based on OrderId
            Example GET response for "/api/order/1":
            {
                "orderId": 1,
                "paymentTypeId": 1,
                "customerId": 1,
                "customer": null,
                "completedDate": "2017-07-17T00:00:00"
            }
        */
        [HttpGet("{id}", Name="GetSingleOrder")]
        public IActionResult Get(int id)
        {
            /*
                This condition validates the values in model binding.
                In this case, it validates that the id value is an integer.
             */
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // from the BangazonAPIContext object, retrieve the a single order record
                Order order = _context.Order.Single(t => t.OrderId == id);

                if (order == null)
                {
                    return NotFound();
                }

                // values will be in JSON format
                return Ok(order);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        /*
            Author: Jason Figueroa
            URL: POST api/order/
            Description:
            This method handles post requests, which adds a
            record to the database. When executing the POST request, do not
            include the orderId in the body of the request. The database will
            assign a uniqure OrderId.
            Example POST body:
            {
                "name": "MacBook Air",
                "serialNumber": "10688",
                "purchaseDate": "2017-01-29T00:00:00",
                "decommissionDate": null
            }
            
            Assuming the newly created id is 24, the return value is:
            {
                "orderId": 24,
                "name": "MacBook Air",
                "serialNumber": "10688",
                "purchaseDate": "2017-01-29T00:00:00",
                "decommissionDate": null
            }
         */
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
