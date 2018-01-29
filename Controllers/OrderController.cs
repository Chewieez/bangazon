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

        [HttpGet("{id}", Name = "GetSingleOrder")]
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
            assign a unique OrderId.
            Example POST body:
            {
                "paymentTypeId": 1,
                "customerId": 1,
                "completedDate": "2018-01-29T00:00:00"
            }
            
            Assuming the newly created id is 18, the return value is:
            {
                "orderId": 18,
                "paymentTypeId": 1,
                "customerId": 1,
                "customer": null,
                "completedDate": "2018-01-29T00:00:00"
            }
         */
        [HttpPost]
        public IActionResult Post([FromBody]Order order)
        {
            /*
                This method will extract the key/value pairs from the JSON
                object that is posted, and create a new instance of the order
                model class, with the corresponding properties set.
                If any of the validations fail, such as length of string values,
                if a value is required, etc., then the API will respond that
                it is a bad request.
             */
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

        /*
            Author: Jason Figueroa
            URL: PUT api/order/{id}
            Description:
            This method handles put requests for order. Users need to 
            provide a full order object to complete the update.
            Example PUT Request:
            PUT /api/order/18
            {
                "orderId": 18,
                "paymentTypeId": 2,
                "customerId": 1,
                "completedDate": "2018-01-29T00:00:00"
            }

            If successful, the return value will match the body of your PUT request.
         */
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
            /*
                The CreatedAtRoute method will return the newly created order in the
                body of the response, and the Location meta-data header will contain
                the URL for the new order resource
            */
            return CreatedAtRoute("GetSingleOrder", new { id = order.OrderId }, order);


        }

        /*
            Author: Jason Figueroa
            URL: DELETE api/order/18
            Description: This method handles DELETE requests for the order records.
        */
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
