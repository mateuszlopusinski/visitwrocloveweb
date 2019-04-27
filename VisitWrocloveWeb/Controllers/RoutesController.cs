using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VisitWrocloveWeb.Models;

namespace VisitWrocloveWeb.Controllers
{
    [AllowAnonymous]
    public class RoutesController : Controller
    {
        private readonly VisitWrocloveWebContext _context;

        public RoutesController(VisitWrocloveWebContext context)
        {
            _context = context;
        }

        // GET: Routes
        public async Task<IActionResult> Index()
        {
            var visitWrocloveWebContext = _context.Route.Include(r => r.User);
            return View(await visitWrocloveWebContext.ToListAsync());
        }

        // GET: Routes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Route
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // GET: Routes/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id");
            return View();
        }

        // POST: Routes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Name,IsPremium,IsPublic,Length,Type,UserId")] Route route)
        {
            if (ModelState.IsValid)
            {
                _context.Add(route);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id", route.UserId);
            return View(route);
        }

        // GET: Routes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Route.FindAsync(id);
            if (route == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id", route.UserId);
            return View(route);
        }

        // POST: Routes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Name,IsPremium,IsPublic,Length,Type,UserId")] Route route)
        {
            if (id != route.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(route);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteExists(route.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id", route.UserId);
            return View(route);
        }

        // GET: Routes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Route
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var route = await _context.Route.FindAsync(id);
            _context.Route.Remove(route);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RouteExists(int id)
        {
            return _context.Route.Any(e => e.Id == id);
        }
    }
}
