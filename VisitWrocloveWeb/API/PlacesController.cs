﻿using System;
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
    public class PlacesController : ControllerBase
    {
        private readonly VisitWrocloveWebContext _context;

        public PlacesController(VisitWrocloveWebContext context)
        {
            _context = context;
        }

        // GET: api/Places
        [HttpGet]
        public IActionResult GetPlace()
        {
            var list = _context.Place.Include(x => x.Address);
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

        // GET: api/Places/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlace([FromRoute] int id)
        {
            var eventReviews = _context.Review.Where(x => x.PlaceEventId.Equals(id)).ToList();
            double rating = 0.0;
            if (eventReviews.Count() > 0)
            {
                double sum = eventReviews.Sum(x => x.Mark);
                double count = eventReviews.Count();
                rating = sum / count;
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lsit = _context.Place.Include(p => p.Address);
            var place = await lsit.FirstOrDefaultAsync(p=> p.Id.Equals(id));

            if (place == null)
            {
                return NotFound();
            }
            place.Rating = rating;

            return new JsonResult(place);
        }

        // PUT: api/Places/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlace([FromRoute] int id, [FromBody] Place place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != place.Id)
            {
                return BadRequest();
            }

            _context.Entry(place).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceExists(id))
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

        // POST: api/Places
        [HttpPost]
        public async Task<IActionResult> PostPlace([FromBody] Place place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Place.Add(place);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlace", new { id = place.Id }, place);
        }

        // DELETE: api/Places/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlace([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var place = await _context.Place.FindAsync(id);
            if (place == null)
            {
                return NotFound();
            }

            _context.Place.Remove(place);
            await _context.SaveChangesAsync();

            return Ok(place);
        }

        private bool PlaceExists(int id)
        {
            return _context.Place.Any(e => e.Id == id);
        }
    }
}