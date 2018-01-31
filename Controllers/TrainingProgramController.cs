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

        /*
            Author: Krys Mathis
            URL: GET api/trainingprogram
            Description:
            Returns the training program values from the database
            Example GET response:
            [ { trainingProgramId: 1,
                name: 'AngualarJS Course',
                startDate: '2018-02-12T00:00:00',
                endDate: '2017-02-16T00:00:00',
                maxAttendance: 25 },
              { trainingProgramId: 2,
                name: 'IT Security Training',
                startDate: '2017-03-19T00:00:00',
                endDate: '2017-03-23T00:00:00',
                maxAttendance: 25 }
            ]
        */
        [HttpGet]
        public IActionResult Get()
        {
            // using the BangazonAPIContext return the values from the TrainingProgram table
            var trainingProgram = _context.TrainingProgram.ToList();

            if (trainingProgram == null)
            {
                return NotFound();
            }
            // values will be in JSON format
            return Ok(trainingProgram);

        }

         /*
            Author: Krys Mathis
            URL: GET api/trainingprogram/{id}
            Description:
            Returns a specific training program based on TrainingProgramId
            Example GET response for "/api/trainingprogram/1":
            { trainingProgramId: 1,
                name: 'AngualarJS Course',
                startDate: '2018-02-12T00:00:00',
                endDate: '2017-02-16T00:00:00',
                maxAttendance: 25 }
         */
        [HttpGet("{id}", Name="GetSingleTrainingProgram")]
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

         /*
            Author: Krys Mathis
            URL: POST api/TrainingProgram/
            Description:
            This method handles post requests, which adds a
            record to the database. When executing the POST request, do not
            include the TrainingProgramId in the body of the request. The database will
            assign a unique id value.

            Example POST body:
            {  name: 'AngualarJS Course',
                startDate: '2018-02-12T00:00:00',
                endDate: '2017-02-16T00:00:00',
                maxAttendance: 25 }
            
            Assuming the newly created id is 14, the return value is:
             {  trainingProgramId: 14,
                name: 'AngualarJS Course',
                startDate: '2018-02-12T00:00:00',
                endDate: '2017-02-16T00:00:00',
                maxAttendance: 25 }

         */
        [HttpPost]
        public IActionResult Post([FromBody]TrainingProgram trainingProgram)
        {
            /*
                This method will extract the key/value pairs from the JSON
                object that is posted, and create a new instance of the TrainingProgram
                model class, with the corresponding properties set.
                If any of the validations fail, such as length of string values,
                if a value is required, etc., then the API will respond that
                it is a bad request.
             */
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

        /*
            Author: Krys Mathis
            URL: PUT api/trainingprogram/{id}
            Description:
            This method handles post requests for training programs. Users need to 
            provide a full object to complete the update.
            Example PUT Request:
            PUT /api/product/14
            {  trainingProgramId: 14,
                name: 'AngualarJS Course',
                startDate: '2018-02-12T00:00:00',
                endDate: '2017-02-16T00:00:00',
                maxAttendance: 25 }

            If successful, the return value will match the body of your PUT request.
         */
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

        /*
            Author: Krys Mathis
            URL: DELETE api/products/1
            Description: This method handles DELETE requests for the training program records.
            Only Future Training Programs are the allowed to deleted
         */
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
