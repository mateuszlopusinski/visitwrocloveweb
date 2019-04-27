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
    public class SavedRoutesController : ControllerBase
    {
        private readonly VisitWrocloveWebContext _context;

        public SavedRoutesController(VisitWrocloveWebContext context)
        {
            _context = context;
        }

        // GET: api/SavedRoutes
        [HttpGet]
        public IEnumerable<SavedRoute> GetSavedRoute()
        {
            return _context.SavedRoute;
        }

        // GET: api/SavedRoutes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSavedRoute([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var savedRoute = await _context.SavedRoute.FindAsync(id);

            if (savedRoute == null)
            {
                return NotFound();
            }

            return Ok(savedRoute);
        }

        // PUT: api/SavedRoutes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSavedRoute([FromRoute] int id, [FromBody] SavedRoute savedRoute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != savedRoute.Id)
            {
                return BadRequest();
            }

            _context.Entry(savedRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SavedRouteExists(id))
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

        // POST: api/SavedRoutes
        [HttpPost]
        public async Task<IActionResult> PostSavedRoute([FromBody] SavedRoute savedRoute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SavedRoute.Add(savedRoute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSavedRoute", new { id = savedRoute.Id }, savedRoute);
        }

        // DELETE: api/SavedRoutes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSavedRoute([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var savedRoute = await _context.SavedRoute.FindAsync(id);
            if (savedRoute == null)
            {
                return NotFound();
            }

            _context.SavedRoute.Remove(savedRoute);
            await _context.SaveChangesAsync();

            return Ok(savedRoute);
        }

        private bool SavedRouteExists(int id)
        {
            return _context.SavedRoute.Any(e => e.Id == id);
        }
    }
}