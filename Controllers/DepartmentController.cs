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
    public class DepartmentController : Controller
    {
        private readonly BangazonAPIContext _context;

         public DepartmentController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        /*
            Author: Dre Randaci
            URL: GET api/department
            Description:
            Returns the department values from the database
            Example GET response:
           {
                "departmentId": 1,
                "name": "IT",
                "expenseBudget": 899000
            },
            {
                "departmentId": 2,
                "name": "Admin",
                "expenseBudget": 500000
            }
        */

        [HttpGet]
        public IActionResult Get()
        {
            // from the BangazonAPIContext object, retrieve the Department table   
            var department = _context.Department.ToList();

            if (department == null)
            {
                return NotFound();
            }
            
            return Ok(department);

        }

        /*
            Author: Dre Randaci
            URL: GET api/department/{id}
            Description:
            Returns a specific department based on DepartmentId
            Example GET response for "/api/department/1":
            
            {
                "departmentId": 1,
                "name": "IT",
                "expenseBudget": 899000
            }

         */
        [HttpGet("{id}", Name="GetSingleDepartment")]
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
                // from the BangazonAPIContext object, retrieve the a single department record
                Department department = _context.Department.Single(d => d.DepartmentId == id);

                if (department == null)
                {
                    return NotFound();
                }

                // values will be in JSON format
                return Ok(department);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }


/*
            Author: Dre Randaci
            URL: POST api/department/
            Description:
            This method handles post requests, which adds a
            record to the database. When executing the POST request, do not
            include the DepartmentId in the body of the request. The database will
            assign a unique DepartmentId.

            Example POST body:
            {
                "name": "Accounting",
                "expenseBudget": 100000
            }
            
            Assuming the newly created id is 5, the return value is:
            {
                "departmentId": 5,
                "name": "Accounting",
                "expenseBudget": 100000
            }

         */
        
        [HttpPost]
        public IActionResult Post([FromBody]Department department)
        {

            /*
                This method will extract the key/value pairs from the JSON
                object that is posted, and create a new instance of the Department
                model class, with the corresponding properties set.
                If any of the validations fail, such as length of string values,
                if a value is required, etc., then the API will respond that
                it is a bad request.
            */

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Department.Add(department);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DepartmentExists(department.DepartmentId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            /*
                The CreatedAtRoute method will return the newly created Department in the
                body of the response, and the Location meta-data header will contain
                the URL for the new Department resource
            */
            return CreatedAtRoute("GetSingleDepartment", new { id = department.DepartmentId }, department);
        }

        /*
            Author: Dre Randaci
            URL: PUT api/department/{id}
            Description:
            This method handles post requests for the department. Users need to 
            provide a full department object to complete the update.
            Example PUT Request:
            PUT /api/deparment/5
            {
                "departmentId": 5,
                "name": "Sales",
                "expenseBudget": 100000
            }

            If successful, the return value will match the body of your PUT request.
         */
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Department.Update(department);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(department.DepartmentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            /*
                The CreatedAtRoute method will return the newly created Department in the
                body of the response, and the Location meta-data header will contain
                the URL for the new Department resource
            */
            return CreatedAtRoute("GetSingleDepartment", new { id = department.DepartmentId }, department);
        }

        private bool DepartmentExists(int departmentId)
        {
            return _context.Department.Any(d => d.DepartmentId == departmentId);
        }
    }
}
