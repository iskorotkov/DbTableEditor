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
    public class PlanetsController : Controller
    {
        private readonly SpaceshipsContext _context;

        public PlanetsController(SpaceshipsContext context)
        {
            _context = context;
        }

        // GET: Planets
        public async Task<IActionResult> Index()
        {
            var spaceshipsContext = _context.Planets.Include(p => p.Empire).Include(p => p.Star);
            return View(await spaceshipsContext.ToListAsync());
        }

        // GET: Planets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planet = await _context.Planets
                .Include(p => p.Empire)
                .Include(p => p.Star)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planet == null)
            {
                return NotFound();
            }

            return View(planet);
        }

        // GET: Planets/Create
        public IActionResult Create()
        {
            ViewData["EmpireId"] = new SelectList(_context.Empires, "Id", "Name");
            ViewData["StarId"] = new SelectList(_context.Stars, "Id", "Name");
            return View();
        }

        // POST: Planets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Approval,EmpireId,Habitability,Population,Size,StarId")] Planet planet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpireId"] = new SelectList(_context.Empires, "Id", "Name", planet.EmpireId);
            ViewData["StarId"] = new SelectList(_context.Stars, "Id", "Name", planet.StarId);
            return View(planet);
        }

        // GET: Planets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planet = await _context.Planets.FindAsync(id);
            if (planet == null)
            {
                return NotFound();
            }
            ViewData["EmpireId"] = new SelectList(_context.Empires, "Id", "Name", planet.EmpireId);
            ViewData["StarId"] = new SelectList(_context.Stars, "Id", "Name", planet.StarId);
            return View(planet);
        }

        // POST: Planets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Approval,EmpireId,Habitability,Population,Size,StarId")] Planet planet)
        {
            if (id != planet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanetExists(planet.Id))
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
            ViewData["EmpireId"] = new SelectList(_context.Empires, "Id", "Name", planet.EmpireId);
            ViewData["StarId"] = new SelectList(_context.Stars, "Id", "Name", planet.StarId);
            return View(planet);
        }

        // GET: Planets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planet = await _context.Planets
                .Include(p => p.Empire)
                .Include(p => p.Star)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planet == null)
            {
                return NotFound();
            }

            return View(planet);
        }

        // POST: Planets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planet = await _context.Planets.FindAsync(id);
            _context.Planets.Remove(planet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanetExists(int id)
        {
            return _context.Planets.Any(e => e.Id == id);
        }
    }
}
