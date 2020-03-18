using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbTableEditor.Data.Context;
using DbTableEditor.Data.Model;

namespace DbTableEditor.AspNetApp.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly SpaceshipsContext _context;

        public SpaceshipsController(SpaceshipsContext context)
        {
            _context = context;
        }

        // GET: Spaceships
        public async Task<IActionResult> Index()
        {
            var spaceshipsContext = _context.Spaceships.Include(s => s.Fleet).Include(s => s.Shipyard);
            return View(await spaceshipsContext.ToListAsync());
        }

        // GET: Spaceships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaceship = await _context.Spaceships
                .Include(s => s.Fleet)
                .Include(s => s.Shipyard)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spaceship == null)
            {
                return NotFound();
            }

            return View(spaceship);
        }

        // GET: Spaceships/Create
        public IActionResult Create()
        {
            ViewData["FleetId"] = new SelectList(_context.Fleets, "Id", "Name");
            ViewData["ShipyardId"] = new SelectList(_context.Shipyards, "Id", "Name");
            return View();
        }

        // POST: Spaceships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Capacity,Energy,Firepower,FleetId,Fuel,Hull,ShipyardId,Speed,Staff,Weight")] Spaceship spaceship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spaceship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FleetId"] = new SelectList(_context.Fleets, "Id", "Name", spaceship.FleetId);
            ViewData["ShipyardId"] = new SelectList(_context.Shipyards, "Id", "Name", spaceship.ShipyardId);
            return View(spaceship);
        }

        // GET: Spaceships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaceship = await _context.Spaceships.FindAsync(id);
            if (spaceship == null)
            {
                return NotFound();
            }
            ViewData["FleetId"] = new SelectList(_context.Fleets, "Id", "Name", spaceship.FleetId);
            ViewData["ShipyardId"] = new SelectList(_context.Shipyards, "Id", "Name", spaceship.ShipyardId);
            return View(spaceship);
        }

        // POST: Spaceships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Capacity,Energy,Firepower,FleetId,Fuel,Hull,ShipyardId,Speed,Staff,Weight")] Spaceship spaceship)
        {
            if (id != spaceship.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spaceship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpaceshipExists(spaceship.Id))
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
            ViewData["FleetId"] = new SelectList(_context.Fleets, "Id", "Name", spaceship.FleetId);
            ViewData["ShipyardId"] = new SelectList(_context.Shipyards, "Id", "Name", spaceship.ShipyardId);
            return View(spaceship);
        }

        // GET: Spaceships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaceship = await _context.Spaceships
                .Include(s => s.Fleet)
                .Include(s => s.Shipyard)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spaceship == null)
            {
                return NotFound();
            }

            return View(spaceship);
        }

        // POST: Spaceships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spaceship = await _context.Spaceships.FindAsync(id);
            _context.Spaceships.Remove(spaceship);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpaceshipExists(int id)
        {
            return _context.Spaceships.Any(e => e.Id == id);
        }
    }
}
