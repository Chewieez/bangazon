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

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            // variable to hold list of employees
            var employee = _context.Employee.ToList();

            // error handling to send a Not Found return if there are no employees.
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);

        }

        // GET api/values/5
        // API to return a single employee
        [HttpGet("{id}", Name="GetSingleEmployee")]
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

        // POST api/values
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
                if (EmployeeExists(employee.EmployeeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleEmployee", new { id = employee.EmployeeId }, employee);
        }

        // PUT api/values/5
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

        private bool EmployeeExists(int EmployeeId)
        {
            return _context.Employee.Any(e => e.EmployeeId == EmployeeId);
        }
    }
}
