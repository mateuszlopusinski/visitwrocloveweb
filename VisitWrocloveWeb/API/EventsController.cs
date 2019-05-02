using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VisitWrocloveWeb.Models;

namespace VisitWrocloveWeb.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly VisitWrocloveWebContext _context;

        public EventsController(VisitWrocloveWebContext context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet]
        public IActionResult GetEvent() 
        {
            var list = _context.Event.Include(x => x.Address);
            foreach (var item in list)
            {
                var eventReviews = _context.Review.Where(x => x.PlaceEventId.Equals(item.Id)).ToList();
                double rating = 0.0;
                if (eventReviews.Count() > 0)
                {
                    double sum = eventReviews.Sum(x => x.Mark);
                    double count = eventReviews.Count();
                    rating = sum / count;
                }
                item.Rating = rating;
            }
            return new JsonResult(list);
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            var eventReviews = _context.Review.Where(x => x.PlaceEventId.Equals(id)).ToList();
            double rating = 0.0;
            if(eventReviews.Count() > 0)
            {
                double sum = eventReviews.Sum(x => x.Mark);
                double count = eventReviews.Count();
                rating = sum / count;
            }
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var list = _context.Event.Include(x => x.Address);
            var @event = await list.FirstOrDefaultAsync(e=> e.Id.Equals(id));

            if (@event == null)
            {
                return NotFound();
            }
            @event.Rating = rating;
            return new JsonResult(@event);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent([FromRoute] int id, [FromBody] Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.Id)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Events
        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Event.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.Id }, @event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();

            return Ok(@event);
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.Id == id);
        }
    }
}