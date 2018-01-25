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

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            
            var productCategory = _context.ProductCategory.ToList();

            if (productCategory == null)
            {
                return NotFound();
            }
            
            return Ok(productCategory);

        }

        // GET api/values/5
        [HttpGet("{id}", Name="GetSingleProductCategory")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ProductCategory productCategory = _context.ProductCategory.Single(t => t.ProductCategoryId == id);

                if (productCategory == null)
                {
                    return NotFound();
                }

                return Ok(productCategory);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductCategory.Add(productCategory);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductCategoryExists(productCategory.ProductCategoryId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleProductCategory", new { id = productCategory.ProductCategoryId }, productCategory);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ProductCategory productCategory)
        {
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
            return CreatedAtRoute("GetSingleProductCategory", new { id = productCategory.ProductCategoryId }, productCategory);


        }

        // DELETE api/values/5
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
