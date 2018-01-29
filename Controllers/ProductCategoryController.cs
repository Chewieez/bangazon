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
    public class ProductCategoryController : Controller
    {
        private readonly BangazonAPIContext _context;

         public ProductCategoryController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        /*
            Author: Krys Mathis
            URL: GET api/productcategory
            Description:
            Returns the product category values from the database
            Example GET response:
            [   { productCategoryId: 1, name: 'Jewelry & Accessories' },
                { productCategoryId: 2, name: 'Clothing & Shoes' },
                { productCategoryId: 3, name: 'Home & Living' },
                { productCategoryId: 4, name: 'Arts & Collectibles' } ]
        */
        [HttpGet]
        public IActionResult Get()
        {
            // from the BangazonAPIContext object, retrieve the ProductCategory table
            var productCategory = _context.ProductCategory.ToList();

            if (productCategory == null)
            {
                return NotFound();
            }
            // values will be in JSON format
            return Ok(productCategory);

        }

        /*
            Author: Krys Mathis
            URL: GET api/productcategory/{id}
            Description:
            Returns a specific product category based on ProductCategoryId
            Example GET response for "/api/productcategory/1":
            { productCategoryId: 1, name: 'Jewelry & Accessories' }
         */

        [HttpGet("{id}", Name="GetSingleProductCategory")]
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
                // from the BangazonAPIContext object, retrieve a single ProductCategory object
                ProductCategory productCategory = _context.ProductCategory.Single(t => t.ProductCategoryId == id);

                if (productCategory == null)
                {
                    return NotFound();
                }
                // values will be in JSON format
                return Ok(productCategory);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        /*
            Author: Krys Mathis
            URL: POST api/productcategory/
            Description:
            This method handles post requests for the product category.
            Example POST body:
            { name: 'Jewelry & Accessories' }
         */
        [HttpPost]
        public IActionResult Post([FromBody]ProductCategory productCategory)
        {
           /*
                Model validation works differently here, since there
                is a complex type being detected with ([FromBody] Child child).
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

            // Add the productCategory to the database context
            _context.ProductCategory.Add(productCategory);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                // Commit the newly created product category to the database
                if (ProductCategoryExists(productCategory.ProductCategoryId))
                {
                    // if the product category already exists
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
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
                To see this run this from command line:
                    curl --header "Content-Type: application/json" -s -X POST -D - --data '{ name: 'Jewelry Accessories & More' }' http://localhost:5000/api/productcategory
                You will see this response:
                    HTTP/1.1 201 Created
                    Date: Mon, 31 Jul 2017 01:04:58 GMT
                    Transfer-Encoding: chunked
                    Content-Type: application/json; charset=utf-8
                    Location: http://localhost:5000/api/productcategory/1
                    Server: Kestrel
                    { productCategoryId: 1, name: 'Jewelry Accessories & More' }
             */
            return CreatedAtRoute("GetSingleProductCategory", new { id = productCategory.ProductCategoryId }, productCategory);
        }

        /*
            Author: Krys Mathis
            URL: PUT api/productcategory/{id}
            Description:
            This method handles post requests for the product category. Users need to 
            provide a full productcategory object to complete the update.
            Example PUT Requst:
            PUT /api/productcategory/1
            { productCategoryId: 1, name: 'Jewelry Accessories & More' }
         */
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ProductCategory productCategory)
        {
            
            /*
                This condition validates the values in model binding.
                In this case, it validates that the id value is an integer.
                If the following URL is requested, model validation will
                fail - because the string of 'chicken' is not an integer -
                and the client will receive a message to that effect.
                    curl -X GET http://localhost:5000/api/productcategory
             */
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductCategory.Update(productCategory);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryExists(productCategory.ProductCategoryId))
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
                return CreatedAtRoute("GetSingleProductCategory", new { id = productCategory.ProductCategoryId }, productCategory);


        }

        /*
            Author: Krys Mathis
            URL: DELETE api/productcategory/1
            Description: This method handles DELETE requests for productcategory records.
         */

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ProductCategory productCategory = _context.ProductCategory.Single(p => p.ProductCategoryId == id);

            if (productCategory == null)
            {
                return NotFound();
            }
            _context.ProductCategory.Remove(productCategory);
            _context.SaveChanges();
            return Ok(productCategory);
        }

        private bool ProductCategoryExists(int productCategoryId)
        {
            return _context.ProductCategory.Any(p => p.ProductCategoryId == productCategoryId);
        }
    }
}
