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
// Api to let users access the Employee resource
/* Example Response:
    {
        "employeeId": 1,
        "departmentId": 1,
        "department": null,
        "firstName": "Kenneth",
        "lastName": "Allen",
        "startDate": "2017-06-11T00:00:00",
        "supervisor": false
    }
*/

namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        // variable to hold the database context
        private readonly BangazonAPIContext _context;

        // injecting the database context into controller
        public EmployeeController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        /*
            Author: Greg Lawrence
            URL: GET api/employee
            Description:
            This method handles GET requests for the employee resource. 
        */

        [HttpGet]
        public IActionResult Get()
        {
            // get the list of employees from database and store in variable
            var employee = _context.Employee.ToList();

            // error handling to send a Not Found return if there are no employees.
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);

        }


        /*
            Author: Greg Lawrence
            URL: GET api/employee/id
            Description:
            This method handles GET requests for a single employee. 
        */
        [HttpGet("{id}", Name = "GetSingleEmployee")]
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
                Employee employee = _context.Employee.Single(e => e.EmployeeId == id);

                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        /*
            Author: Greg Lawrence
            URL: POST api/employee
            Description:
            This method handles POST requests to create a single employee.
            When executing the POST request, do not
            include the EmployeeId in the body of the request. The database will
            assign a unique EmployeeId. 
        */
        [HttpPost]
        public IActionResult Post([FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employee.Add(employee);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                // check if the Employee Id already exists in the database, if it does, throw an error
                if (EmployeeExists(employee.EmployeeId))
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
                the URL for the new employee resource
             */
            return CreatedAtRoute("GetSingleEmployee", new { id = employee.EmployeeId }, employee);
        }

        /*
            Author: Greg Lawrence
            URL: PUT api/employee/id
            Description:
            This method handles PUT requests to edit a single employee resource. You need to send in the entire object to edit including employeeId, not just the fields you want to edit.  
        */
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employee.Update(employee);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employee.EmployeeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleEmployee", new { id = employee.EmployeeId }, employee);
        }

        /*
            Author: Greg Lawrence
            Description:
            This method checks if a employee with the passed in Id exists in the database and returns True or False. 
        */
        private bool EmployeeExists(int EmployeeId)
        {
            return _context.Employee.Any(e => e.EmployeeId == EmployeeId);
        }
    }
}
