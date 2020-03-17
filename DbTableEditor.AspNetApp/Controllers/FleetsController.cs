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
    public class FleetsController : Controller
    {
        private readonly SpaceshipsContext _context;

        public FleetsController(SpaceshipsContext context)
        {
            _context = context;
        }

        // GET: Fleets
        public async Task<IActionResult> Index()
        {
            var spaceshipsContext = _context.Fleets.Include(f => f.Commander).Include(f => f.Status);
            return View(await spaceshipsContext.ToListAsync());
        }

        // GET: Fleets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fleet = await _context.Fleets
                .Include(f => f.Commander)
                .Include(f => f.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fleet == null)
            {
                return NotFound();
            }

            return View(fleet);
        }

        // GET: Fleets/Create
        public IActionResult Create()
        {
            ViewData["CommanderId"] = new SelectList(_context.Commanders, "Id", "Name");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name");
            return View();
        }

        // POST: Fleets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CommanderId,StatusId")] Fleet fleet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fleet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommanderId"] = new SelectList(_context.Commanders, "Id", "Name", fleet.CommanderId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", fleet.StatusId);
            return View(fleet);
        }

        // GET: Fleets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fleet = await _context.Fleets.FindAsync(id);
            if (fleet == null)
            {
                return NotFound();
            }
            ViewData["CommanderId"] = new SelectList(_context.Commanders, "Id", "Name", fleet.CommanderId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", fleet.StatusId);
            return View(fleet);
        }

        // POST: Fleets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CommanderId,StatusId")] Fleet fleet)
        {
            if (id != fleet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fleet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FleetExists(fleet.Id))
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
            ViewData["CommanderId"] = new SelectList(_context.Commanders, "Id", "Name", fleet.CommanderId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", fleet.StatusId);
            return View(fleet);
        }

        // GET: Fleets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fleet = await _context.Fleets
                .Include(f => f.Commander)
                .Include(f => f.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fleet == null)
            {
                return NotFound();
            }

            return View(fleet);
        }

        // POST: Fleets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fleet = await _context.Fleets.FindAsync(id);
            _context.Fleets.Remove(fleet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FleetExists(int id)
        {
            return _context.Fleets.Any(e => e.Id == id);
        }
    }
}
