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
    public class FavoritesController : ControllerBase
    {
        private readonly VisitWrocloveWebContext _context;

        public FavoritesController(VisitWrocloveWebContext context)
        {
            _context = context;
        }

        // GET: api/Favorites
        [HttpGet]
        public IEnumerable<Favorite> GetFavorite()
        {
            var list = _context.Favorite
                .Include(f => f.User)
                .Include(f => f.PlaceEvent);
            return list;
        }

        // GET: api/Favorites/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFavorite([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var list = _context.Favorite
                .Include(f => f.User)
                .Include(f => f.PlaceEvent);
            var favorite = await list.FirstOrDefaultAsync(f => f.Id.Equals(id));

            if (favorite == null)
            {
                return NotFound();
            }

            return Ok(favorite);
        }

        // PUT: api/Favorites/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavorite([FromRoute] int id, [FromBody] Favorite favorite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != favorite.Id)
            {
                return BadRequest();
            }

            _context.Entry(favorite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteExists(id))
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

        // POST: api/Favorites
        [HttpPost]
        public async Task<IActionResult> PostFavorite([FromBody] Favorite favorite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Favorite.Add(favorite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavorite", new { id = favorite.Id }, favorite);
        }

        // DELETE: api/Favorites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var favorite = await _context.Favorite.FindAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }

            _context.Favorite.Remove(favorite);
            await _context.SaveChangesAsync();

            return Ok(favorite);
        }

        private bool FavoriteExists(int id)
        {
            return _context.Favorite.Any(e => e.Id == id);
        }
    }
}