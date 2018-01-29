using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

// Author: Greg Lawrence
// Api to let users access the Customer resource
/* Example Response:
    {
        "customerId": 1,
        "firstName": "Stacy",
        "lastName": "Gauger",
        "creationDate": "2017-06-21T00:00:00",
        "lastLoginDate": "2018-01-24T00:00:00"
    } 
*/

namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        // variable to hold the database context
        private readonly BangazonAPIContext _context;

        // injecting the database context into controller
        public CustomerController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }


        /*
            Author: Krys Mathis building on Greg Lawrence's code
            URL-1: GET api/customer/
            URL-2: GET api/customer/?active=false
            Description:
            This method handles GET requests for the customer resource. When 
            using the optional paramater a list of customers that either 
            have orders:
                /api/customer/?active=true - customers that have placed orders
                /api/customer/?active=false - customers without orders
         */
 

        [HttpGet]
        public IActionResult Get(bool? active)
        {
            // if GET includes the 'active' parameter
            if (active != null) {
                
                if (active == true) {
                    // return customers that have matching customer id's in the order table
                    var customer = _context.Customer.Where(c => 
                        _context.Order.Any(o => o.CustomerId == c.CustomerId));

                    return Ok(customer);

                } else if (active == false)  {
                    // return customers without matching customer id's in the order table
                    var customer = _context.Customer.Where(c => 
                        !_context.Order.Any(o => o.CustomerId == c.CustomerId));

                    return Ok(customer);

                } else {
                    // if the input was neither "true" or "false"
                    return NotFound();
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


        /*
            Author: Greg Lawrence
            URL: GET api/customer/id
            Description:
            This method handles GET requests for a single customer. 
        */
        [HttpGet("{id:int}", Name="GetSingleCustomer")]
        public IActionResult Get(int id)
        {
            // error handling to check if the user inputted the correct info to use API, in this case, an integer
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // search database context and try to find a match for the employee id submitted
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


        /*
            Author: Greg Lawrence
            URL: POST api/customer
            Description:
            This method handles POST requests to create a single customer. 
        */
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
                // check if the customer Id already exists in the database, if it does, throw an error
                if (CustomerExists(customer.CustomerId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            /*
                The CreatedAtRoute method will return the newly created employee in the
                body of the response, and the Location meta-data header will contain
                the URL for the new employee resource.
                Example response:
                {
                    "customerId": 1,
                    "firstName": "Stacy",
                    "lastName": "Gauger",
                    "creationDate": "2017-06-21T00:00:00",
                    "lastLoginDate": "2018-01-24T00:00:00"
                }
             */
            return CreatedAtRoute("GetSingleCustomer", new { id = customer.CustomerId }, customer);
        }

        /*
            Author: Greg Lawrence
            URL: PUT api/customer/id
            Description:
            This method handles PUT requests to edit a single customer resource. You need to send in the entire object to edit including customerId, not just the fields you want to edit.  
        */
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Customer customer)
        {
            // error handling to check if the user inputted the correct info to use API, in this case, an integer
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
                // check if the Customer Id already exists in the database, if it does, throw an error
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

         /*
            Author: Greg Lawrence
            Description:
            This method checks if a employee with the passed in Id exists in the database True or False.  
        */        
        private bool CustomerExists(int CustomerId)
        {
            return _context.Customer.Any(c => c.CustomerId == CustomerId);
        }
    }
}
