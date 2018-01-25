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
    public class ComputerEmployeeController : Controller
    {
        private readonly BangazonAPIContext _context;

         public ComputerEmployeeController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            
            var computerEmployee = _context.ComputerEmployee.ToList();

            if (computerEmployee == null)
            {
                return NotFound();
            }
            return Ok(computerEmployee);

        }

        // GET api/values/5
        [HttpGet("{id}", Name="GetSingleComputerEmployee")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ComputerEmployee computerEmployee = _context.ComputerEmployee.Single(t => t.ComputerEmployeeId == id);

                if (computerEmployee == null)
                {
                    return NotFound();
                }

                return Ok(computerEmployee);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ComputerEmployee computerEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ComputerEmployee.Add(computerEmployee);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ComputerEmployeeExists(computerEmployee.ComputerEmployeeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleComputerEmployee", new { id = computerEmployee.ComputerEmployeeId }, computerEmployee);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ComputerEmployee computerEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ComputerEmployee.Update(computerEmployee);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputerEmployeeExists(computerEmployee.ComputerEmployeeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleComputerEmployee", new { id = computerEmployee.ComputerEmployeeId }, computerEmployee);


        }

        // should we remove the ability to delete records from the ComputerEmployee table
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ComputerEmployee computerEmployee = _context.ComputerEmployee.Single(t => t.ComputerEmployeeId == id);

            if (computerEmployee == null)
            {
                return NotFound();
            }
            _context.ComputerEmployee.Remove(computerEmployee);
            _context.SaveChanges();
            return Ok(computerEmployee);
        }

        private bool ComputerEmployeeExists(int computerEmployeeId)
        {
            return _context.ComputerEmployee.Any(g => g.ComputerEmployeeId == computerEmployeeId);
        }
    }
}
