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
    public class ShipyardsController : Controller
    {
        private readonly SpaceshipsContext _context;

        public ShipyardsController(SpaceshipsContext context)
        {
            _context = context;
        }

        // GET: Shipyards
        public async Task<IActionResult> Index()
        {
            var spaceshipsContext = _context.Shipyards.Include(s => s.Planet);
            return View(await spaceshipsContext.ToListAsync());
        }

        // GET: Shipyards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipyard = await _context.Shipyards
                .Include(s => s.Planet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shipyard == null)
            {
                return NotFound();
            }

            return View(shipyard);
        }

        // GET: Shipyards/Create
        public IActionResult Create()
        {
            ViewData["PlanetId"] = new SelectList(_context.Planets, "Id", "Name");
            return View();
        }

        // POST: Shipyards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Pipelines,PlanetId,Staff")] Shipyard shipyard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shipyard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlanetId"] = new SelectList(_context.Planets, "Id", "Name", shipyard.PlanetId);
            return View(shipyard);
        }

        // GET: Shipyards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipyard = await _context.Shipyards.FindAsync(id);
            if (shipyard == null)
            {
                return NotFound();
            }
            ViewData["PlanetId"] = new SelectList(_context.Planets, "Id", "Name", shipyard.PlanetId);
            return View(shipyard);
        }

        // POST: Shipyards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Pipelines,PlanetId,Staff")] Shipyard shipyard)
        {
            if (id != shipyard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shipyard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipyardExists(shipyard.Id))
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
            ViewData["PlanetId"] = new SelectList(_context.Planets, "Id", "Name", shipyard.PlanetId);
            return View(shipyard);
        }

        // GET: Shipyards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipyard = await _context.Shipyards
                .Include(s => s.Planet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shipyard == null)
            {
                return NotFound();
            }

            return View(shipyard);
        }

        // POST: Shipyards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shipyard = await _context.Shipyards.FindAsync(id);
            _context.Shipyards.Remove(shipyard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipyardExists(int id)
        {
            return _context.Shipyards.Any(e => e.Id == id);
        }
    }
}
