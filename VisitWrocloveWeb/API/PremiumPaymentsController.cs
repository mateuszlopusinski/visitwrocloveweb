using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisitWrocloveWeb.Models;

namespace VisitWrocloveWeb.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumPaymentsController : ControllerBase
    {
        private readonly VisitWrocloveWebContext _context;

        public PremiumPaymentsController(VisitWrocloveWebContext context)
        {
            _context = context;
        }

        // GET: api/PremiumPayments
        [HttpGet]
        public IEnumerable<PremiumPayment> GetPremiumPayment()
        {
            var list = _context.PremiumPayment
                .Include(pp => pp.User);
            return list;
        }

        // GET: api/PremiumPayments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPremiumPayment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var list = _context.PremiumPayment
                .Include(pp => pp.User);
            var premiumPayment = await list.FirstOrDefaultAsync(pp=>pp.Id.Equals(id));

            if (premiumPayment == null)
            {
                return NotFound();
            }

            return Ok(premiumPayment);
        }

        // PUT: api/PremiumPayments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPremiumPayment([FromRoute] int id, [FromBody] PremiumPayment premiumPayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != premiumPayment.Id)
            {
                return BadRequest();
            }

            _context.Entry(premiumPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PremiumPaymentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PremiumPayments
        [HttpPost]
        public async Task<IActionResult> PostPremiumPayment([FromBody] PremiumPayment premiumPayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PremiumPayment.Add(premiumPayment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPremiumPayment", new { id = premiumPayment.Id }, premiumPayment);
        }

        // DELETE: api/PremiumPayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePremiumPayment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var premiumPayment = await _context.PremiumPayment.FindAsync(id);
            if (premiumPayment == null)
            {
                return NotFound();
            }

            _context.PremiumPayment.Remove(premiumPayment);
            await _context.SaveChangesAsync();

            return Ok(premiumPayment);
        }

        private bool PremiumPaymentExists(int id)
        {
            return _context.PremiumPayment.Any(e => e.Id == id);
        }
    }
}