using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisitWrocloveWeb.Models;
using VisitWrocloveWeb.Resolver;

namespace VisitWrocloveWeb.API
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsResolver _resolver;
        private readonly VisitWrocloveWebContext _context;

        public PaymentsController(VisitWrocloveWebContext context, IPaymentsResolver resolver)
        {
            _context = context;
            _resolver = resolver;
        }

        [HttpPost]
        public async Task<IActionResult> PostFavorite([FromBody] Payment payment)
        {
            var user = _context.User.FirstOrDefault(x => x.Id.Equals(payment.UserId));
            var result = await _resolver.ResovlePayment(payment, user);
            if (result)
            {
                user.IsPremium = true;
                _context.Entry(user).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(payment.UserId))
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
            return Ok(result);

        }
        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}