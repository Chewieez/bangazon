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
    public class CustomerController : Controller
    {
        private readonly BangazonAPIContext _context;

         public CustomerController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get(string active)
        {
            // if the search for active
            if (active != null) {
                 
                switch (active) {
                    case "true": {
                        var customer = _context.Customer.Where(c => 
                            _context.Order.Any(o => o.CustomerId == c.CustomerId));

                        return Ok(customer);
                    }

                    case "false": {
                        
                        var customer = _context.Customer.Where(c => 
                            !_context.Order.Any(o => o.CustomerId == c.CustomerId));

                        return Ok(customer);
                    }

                    default: {
                        return NotFound();
                    }
                }
                


            } else {
                 var customer = _context.Customer.ToList();

                if (customer == null)
                {
                    return NotFound();
                }
                    return Ok(customer);
            }


        }


        // GET api/[controller]/5
        [HttpGet("{id:int}", Name="GetSingleCustomer")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Customer customer = _context.Customer.Single(c => c.CustomerId == id);

                if (customer == null)
                {
                    return NotFound();
                }

                return Ok(customer);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Customer.Add(customer);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CustomerExists(customer.CustomerId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleCustomer", new { id = customer.CustomerId }, customer);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Customer.Update(customer);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(customer.CustomerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleCustomer", new { id = customer.CustomerId }, customer);


        }

        private bool CustomerExists(int CustomerId)
        {
            return _context.Customer.Any(c => c.CustomerId == CustomerId);
        }
    }
}
