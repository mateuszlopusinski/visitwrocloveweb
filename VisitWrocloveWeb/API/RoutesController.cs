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
    public class RoutesController : ControllerBase
    {
        private readonly VisitWrocloveWebContext _context;

        public RoutesController(VisitWrocloveWebContext context)
        {
            _context = context;
        }

        // GET: api/Routes
        [HttpGet]
        public IActionResult GetRoute()
        {
            var list = _context.Route
                .Include(r => r.User);
            return new JsonResult(list);
        }

        // GET: api/Routes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoute([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var list = _context.Route
                .Include(r => r.User);
            var route = await list.FirstOrDefaultAsync(r => r.Id.Equals(id));

            if (route == null)
            {
                return NotFound();
            }

            return new JsonResult(route);
        }

        // PUT: api/Routes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoute([FromRoute] int id, [FromBody] Route route)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != route.Id)
            {
                return BadRequest();
            }

            _context.Entry(route).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteExists(id))
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

        // POST: api/Routes
        [HttpPost]
        public async Task<IActionResult> PostRoute([FromBody] Route route)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Route.Add(route);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoute", new { id = route.Id }, route);
        }

        // DELETE: api/Routes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoute([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var route = await _context.Route.FindAsync(id);
            if (route == null)
            {
                return NotFound();
            }

            _context.Route.Remove(route);
            await _context.SaveChangesAsync();

            return Ok(route);
        }

        private bool RouteExists(int id)
        {
            return _context.Route.Any(e => e.Id == id);
        }
    }
}