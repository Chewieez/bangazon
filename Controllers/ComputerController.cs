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
    public class ComputerController : Controller
    {
        private readonly BangazonAPIContext _context;

         public ComputerController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        /*
            Author: Jason Figueroa
            URL: GET api/computer
            Description:
            Returns the computer values from the database
            Example GET response:
            [
                {
                    "computerId": 1,
                    "name": "Microsoft Surface Laptop",
                    "serialNumber": "11202",
                    "purchaseDate": "2017-01-23T00:00:00",
                    "decommissionDate": null
                },
                {
                    "computerId": 2,
                    "name": "Dell Inspiron 7000",
                    "serialNumber": "33319",
                    "purchaseDate": "2017-05-21T00:00:00",
                    "decommissionDate": null
                }
            ]
        */
        [HttpGet]
        public IActionResult Get()
        {
            
            // from the BangazonAPIContext object, retrieve the Product table
            var computer = _context.Computer.ToList();

            if (computer == null)
            {
                return NotFound();
            }

            // values will be in JSON format
            return Ok(computer);

        }

        /*
            Author: Krys Mathis
            URL: GET api/product/{id}
            Description:
            Returns a specific product based on ProductId
            Example GET response for "/api/computer/1":
            {
                "computerId": 1,
                "name": "Microsoft Surface Laptop",
                "serialNumber": "11202",
                "purchaseDate": "2017-01-23T00:00:00",
                "decommissionDate": null
            }
        */
        [HttpGet("{id}", Name="GetSingleComputer")]
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
                // from the BangazonAPIContext object, retrieve the a single computer record
                Computer computer = _context.Computer.Single(t => t.ComputerId == id);

                if (computer == null)
                {
                    return NotFound();
                }

                // values will be in JSON format
                return Ok(computer);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        /*
            Author: Jason Figueroa
            URL: POST api/computer/
            Description:
            This method handles post requests, which adds a
            record to the database. When executing the POST request, do not
            include the computerId in the body of the request. The database will
            assign a uniqure ComputerId.
            Example POST body:
            {
                "name": "MacBook Air",
                "serialNumber": "10688",
                "purchaseDate": "2017-01-29T00:00:00",
                "decommissionDate": null
            }
            
            Assuming the newly created id is 24, the return value is:
            {
                "computerId": 24,
                "name": "MacBook Air",
                "serialNumber": "10688",
                "purchaseDate": "2017-01-29T00:00:00",
                "decommissionDate": null
            }
         */
        [HttpPost]
        public IActionResult Post([FromBody]Computer computer)
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

            _context.Computer.Add(computer);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ComputerExists(computer.ComputerId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleComputer", new { id = computer.ComputerId }, computer);
        }

        /*
            Author: Jason Figueroa
            URL: PUT api/computer/{id}
            Description:
            This method handles put requests for computer. Users need to 
            provide a full computer object to complete the update.
            Example PUT Request:
            PUT /api/computer/24
            {
                "computerId": 24,
                "name": "MacBook Pro",
                "serialNumber": "10688",
                "purchaseDate": "2017-01-29T00:00:00",
                "decommissionDate": null
            }

            If successful, the return value will match the body of your PUT request.
         */
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Computer computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Computer.Update(computer);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputerExists(computer.ComputerId))
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
            return CreatedAtRoute("GetSingleComputer", new { id = computer.ComputerId }, computer);

        }

        /*
            Author: Jason Figueroa
            URL: DELETE api/computer/24
            Description: This method handles DELETE requests for the computer records.
         */
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Computer computer = _context.Computer.Single(t => t.ComputerId == id);

            if (computer == null)
            {
                return NotFound();
            }
            _context.Computer.Remove(computer);
            _context.SaveChanges();
            return Ok(computer);
        }

        private bool ComputerExists(int computerId)
        {
            return _context.Computer.Any(g => g.ComputerId == computerId);
        }
    }
}
