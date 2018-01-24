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
    public class TrainingProgramController : Controller
    {
        private readonly BangazonAPIContext _context;

         public TrainingProgramController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            
            var trainingProgram = _context.TrainingProgram.ToList();

            if (trainingProgram == null)
            {
                return NotFound();
            }
            return Ok(trainingProgram);

        }

        // GET api/values/5
        [HttpGet("{id}", Name="GetSingleTrainingProgram")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                TrainingProgram trainingProgram = _context.TrainingProgram.Single(t => t.TrainingProgramId == id);

                if (trainingProgram == null)
                {
                    return NotFound();
                }

                return Ok(trainingProgram);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]TrainingProgram trainingProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TrainingProgram.Add(trainingProgram);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TrainingProgramExists(trainingProgram.TrainingProgramId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleTrainingProgram", new { id = trainingProgram.TrainingProgramId }, trainingProgram);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TrainingProgram trainingProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TrainingProgram.Update(trainingProgram);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingProgramExists(trainingProgram.TrainingProgramId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleTrainingProgram", new { id = trainingProgram.TrainingProgramId }, trainingProgram);


        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TrainingProgram trainingProgram = _context.TrainingProgram.Single(t => t.TrainingProgramId == id && t.StartDate > DateTime.Now);

            if (trainingProgram == null)
            {
                return NotFound();
            }
            _context.TrainingProgram.Remove(trainingProgram);
            _context.SaveChanges();
            return Ok(trainingProgram);
        }

        private bool TrainingProgramExists(int trainingProgramId)
        {
            return _context.TrainingProgram.Any(g => g.TrainingProgramId == trainingProgramId);
        }
    }
}
