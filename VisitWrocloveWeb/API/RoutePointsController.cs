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
    public class RoutePointsController : ControllerBase
    {
        private readonly VisitWrocloveWebContext _context;

        public RoutePointsController(VisitWrocloveWebContext context)
        {
            _context = context;
        }

        // GET: api/RoutePoints
        [HttpGet]
        public IActionResult GetRoutePoint()
        {
            var list = _context.RoutePoint
                .Include(rp => rp.PlaceEvent)
                .Include(rp => rp.Route);
            return new JsonResult(list);
        }

        // GET: api/RoutePoints/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoutePoint([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var list = _context.RoutePoint
                .Include(rp => rp.PlaceEvent)
                .Include(rp => rp.Route);
            var routePoint = await list.FirstOrDefaultAsync(rp => rp.Id.Equals(id));

            if (routePoint == null)
            {
                return NotFound();
            }

            return new JsonResult(routePoint);
        }

        // PUT: api/RoutePoints/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoutePoint([FromRoute] int id, [FromBody] RoutePoint routePoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != routePoint.Id)
            {
                return BadRequest();
            }

            _context.Entry(routePoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoutePointExists(id))
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

        // POST: api/RoutePoints
        [HttpPost]
        public async Task<IActionResult> PostRoutePoint([FromBody] RoutePoint routePoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RoutePoint.Add(routePoint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoutePoint", new { id = routePoint.Id }, routePoint);
        }

        // DELETE: api/RoutePoints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoutePoint([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var routePoint = await _context.RoutePoint.FindAsync(id);
            if (routePoint == null)
            {
                return NotFound();
            }

            _context.RoutePoint.Remove(routePoint);
            await _context.SaveChangesAsync();

            return Ok(routePoint);
        }

        private bool RoutePointExists(int id)
        {
            return _context.RoutePoint.Any(e => e.Id == id);
        }
    }
}