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

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            
            var computer = _context.Computer.ToList();

            if (computer == null)
            {
                return NotFound();
            }
            return Ok(computer);

        }

        // GET api/values/5
        [HttpGet("{id}", Name="GetSingleComputer")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Computer computer = _context.Computer.Single(t => t.ComputerId == id);

                if (computer == null)
                {
                    return NotFound();
                }

                return Ok(computer);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Computer computer)
        {
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

        // PUT api/values/5
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
            return CreatedAtRoute("GetSingleComputer", new { id = computer.ComputerId }, computer);


        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Computer computer = _context.Computer.Single(t => t.ComputerId == id && t.PurchaseDate > DateTime.Now);

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
