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
    public class ProductController : Controller
    {
        private readonly BangazonAPIContext _context;

         public ProductController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        /*
            Author: Krys Mathis
            URL: GET api/product
            Description:
            Returns the product values from the database
            Example GET response:
           [ { productId: 1,
                productCategoryId: 2,
                productCategory: null,
                customerId: 1,
                customer: null,
                name: 'Knit Hat',
                price: 25,
                description: 'A beautifully knitted hat for a toddler girl.',
                quantity: 2 },
            { productId: 2,
                productCategoryId: 2,
                productCategory: null,
                customerId: 1,
                customer: null,
                name: 'Knit Scarf',
                price: 25,
                description: 'A beautifully knitted scarf for a toddler girl.',
                quantity: 4 }
           ]
        */
        [HttpGet]
        public IActionResult Get()
        {
            // from the BangazonAPIContext object, retrieve the Product table
            var product = _context.Product.ToList();

            if (product == null)
            {
                return NotFound();
            }
            
            // values will be in JSON format
            return Ok(product);

        }

         /*
            Author: Krys Mathis
            URL: GET api/product/{id}
            Description:
            Returns a specific product based on ProductId
            Example GET response for "/api/product/1":
            {   productId: 1,
                productCategoryId: 2,
                productCategory: null,
                customerId: 1,
                customer: null,
                name: 'Knit Hat',
                price: 25,
                description: 'A beautifully knitted hat for a toddler girl.',
                quantity: 2 }
         */
        [HttpGet("{id}", Name="GetSingleProduct")]
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
                // from the BangazonAPIContext object, retrieve the a single product record
                Product product = _context.Product.Single(t => t.ProductId == id);

                if (product == null)
                {
                    return NotFound();
                }
                // values will be in JSON format
                return Ok(product);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

         /*
            Author: Krys Mathis
            URL: POST api/product/
            Description:
            This method handles post requests, which adds a
            record to the database. When executing the POST request, do not
            include the productId in the body of the request. The database will
            assign a uniqure ProductId.

            Example POST body:
            {   
                productCategoryId: 2,
                productCategory: null,
                customerId: 1,
                customer: null,
                name: 'Bowler Hat',
                price: 25,
                description: 'Charlie Chaplin.',
                quantity: 2 }
            
            Assuming the newly created id is 14, the return value is:
            {   productId: 14,
                productCategoryId: 2,
                productCategory: null,
                customerId: 1,
                customer: null,
                name: 'Bowler Hat',
                price: 25,
                description: 'Charlie Chaplin.',
                quantity: 2 }

         */
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            /*
                This method will extract the key/value pairs from the JSON
                object that is posted, and create a new instance of the Child
                model class, with the corresponding properties set.
                If any of the validations fail, such as length of string values,
                if a value is required, etc., then the API will respond that
                it is a bad request.
             */

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Product.Add(product);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.ProductId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleProduct", new { id = product.ProductId }, product);
        }

        /*
            Author: Krys Mathis
            URL: PUT api/product/{id}
            Description:
            This method handles post requests for the product. Users need to 
            provide a full product object to complete the update.
            Example PUT Request:
            PUT /api/product/14
            {   productId: 14,
                productCategoryId: 2,
                productCategory: null,
                customerId: 1,
                customer: null,
                name: 'Bowler Hat',
                price: 25,
                description: 'Charlie Chaplin.',
                quantity: 2 }

            If successful, the return value will match the body of your PUT request.
         */
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Product.Update(product);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            /*
                The CreatedAtRoute method will return the newly created child in the
                body of the response, and the Location meta-data header will contain
                the URL for the new child resource
            */
            return CreatedAtRoute("GetSingleProduct", new { id = product.ProductId }, product);


        }

        /*
            Author: Krys Mathis
            URL: DELETE api/products/1
            Description: This method handles DELETE requests for the product records.
         */

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _context.Product.Single(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            _context.Product.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }

        private bool ProductExists(int productId)
        {
            return _context.Product.Any(p => p.ProductId == productId);
        }
    }
}
