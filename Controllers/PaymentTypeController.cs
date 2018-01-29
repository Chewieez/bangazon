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
    public class PaymentTypeController : Controller
    {
        private readonly BangazonAPIContext _context;

         public PaymentTypeController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        /*
            Author: Krys Mathis
            URL: GET api/paymenttype/
            Description:
            Handles return all payment type records from the database
            Example GET body:
                {
                    "toyname": "Hot wheels",
                    "childname": "Samantha Young"
                }
         */

        [HttpGet]
        public IActionResult Get()
        {
            
            var paymentType = _context.PaymentType.ToList();

            if (paymentType == null)
            {
                return NotFound();
            }
            return Ok(paymentType);

        }

        // GET api/values/5
        [HttpGet("{id}", Name="GetSinglePaymentType")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                PaymentType paymentType = _context.PaymentType.Single(p => p.PaymentTypeId == id);

                if (paymentType == null)
                {
                    return NotFound();
                }

                return Ok(paymentType);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PaymentType.Add(paymentType);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PaymentTypeExists(paymentType.PaymentTypeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSinglePaymentType", new { id = paymentType.PaymentTypeId }, paymentType);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PaymentType.Update(paymentType);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTypeExists(paymentType.PaymentTypeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSinglePaymentType", new { id = paymentType.PaymentTypeId }, paymentType);


        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            PaymentType paymentType = _context.PaymentType.Single(t => t.PaymentTypeId == id);

            if (paymentType == null)
            {
                return NotFound();
            }
            _context.PaymentType.Remove(paymentType);
            _context.SaveChanges();
            return Ok(paymentType);
        }

        private bool PaymentTypeExists(int paymentTypeId)
        {
            return _context.PaymentType.Any(p => p.PaymentTypeId == paymentTypeId);
        }
    }
}
