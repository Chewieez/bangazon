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
            Author: Dre Randaci
            URL: GET api/PaymentType
            Description:
            Returns the paymentType values from the database
            Example GET response:
           {
                "paymentTypeId": 1,
                "name": "PayPal",
                "customerId": 1,
                "customer": null,
                "accountNumber": 11111
            },
            {
                "paymentTypeId": 2,
                "name": "Apple Pay",
                "customerId": 1,
                "customer": null,
                "accountNumber": 22221
            }
        */

        [HttpGet]
        public IActionResult Get()
        {
            // from the BangazonAPIContext object, retrieve the PaymentType table
            var paymentType = _context.PaymentType.ToList();

            if (paymentType == null)
            {
                return NotFound();
            }

            // values will be in JSON format
            return Ok(paymentType);

        }

        /*
            Author: Dre Randaci
            URL: GET api/PaymentType/{id}
            Description:
            Returns a specific PaymentType based on PaymentTypeId
            Example GET response for "/api/PaymentType/1":
            {
                "paymentTypeId": 1,
                "name": "PayPal",
                "customerId": 1,
                "customer": null,
                "accountNumber": 11111
            }
         */

        [HttpGet("{id}", Name="GetSinglePaymentType")]
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
                // from the BangazonAPIContext object, retrieve the a single PaymentType record
                PaymentType paymentType = _context.PaymentType.Single(p => p.PaymentTypeId == id);

                if (paymentType == null)
                {
                    return NotFound();
                }
                // values will be in JSON format
                return Ok(paymentType);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        /*
            Author: Dre Randaci
            URL: POST api/PaymentType/
            Description:
            This method handles post requests, which adds a
            record to the database. When executing the POST request, do not
            include the paymentTypeId in the body of the request. The database will
            assign a unique paymentTypeId.

            Example POST body:
            {
                "name": "Apple Pay",
                "customerId": 1,
                "customer": null,
                "accountNumber": 565722828
            }

         */

        [HttpPost]
        public IActionResult Post([FromBody]PaymentType paymentType)
        {

            /*
                This method will extract the key/value pairs from the JSON
                object that is posted, and create a new instance of the PaymentType
                model class, with the corresponding properties set.
                If any of the validations fail, such as length of string values,
                if a value is required, etc., then the API will respond that
                it is a bad request.
            */

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
            /*
                The CreatedAtRoute method will return the newly created PaymentType in the
                body of the response, and the Location meta-data header will contain
                the URL for the new PaymentType resource
            */
            return CreatedAtRoute("GetSinglePaymentType", new { id = paymentType.PaymentTypeId }, paymentType);
        }

        /*
            Author: Dre Randaci
            URL: PUT api/PaymentType/{id}
            Description:
            This method handles post requests for the PaymentType. Users need to 
            provide a full PaymentType object to complete the update.
            Example PUT Request:
            PUT /api/PaymentType/9
            {
                "paymentTypeId": 9,
                "name": "AmEx",
                "customerId": 1,
                "customer": null,
                "accountNumber": 565722828
            }

            If successful, the return value will match the body of your PUT request.
         */
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
            /*
                The CreatedAtRoute method will return the newly created PaymentType in the
                body of the response, and the Location meta-data header will contain
                the URL for the new PaymentType resource
            */
            return CreatedAtRoute("GetSinglePaymentType", new { id = paymentType.PaymentTypeId }, paymentType);


        }

        /*
            Author: Dre Randaci
            URL: DELETE api/PaymentType/9
            Description: This method handles DELETE requests for the PaymentType records. Only requires the ID of the resource/row being deleted
        */

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
