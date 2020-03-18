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
    public class EmpiresController : Controller
    {
        private readonly SpaceshipsContext _context;

        public EmpiresController(SpaceshipsContext context)
        {
            _context = context;
        }

        // GET: Empires
        public async Task<IActionResult> Index()
        {
            var spaceshipsContext = _context.Empires.Include(e => e.GovernmentType);
            return View(await spaceshipsContext.ToListAsync());
        }

        // GET: Empires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empire = await _context.Empires
                .Include(e => e.GovernmentType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empire == null)
            {
                return NotFound();
            }

            return View(empire);
        }

        // GET: Empires/Create
        public IActionResult Create()
        {
            ViewData["GovernmentTypeId"] = new SelectList(_context.GovernmentTypes, "Id", "Name");
            return View();
        }

        // POST: Empires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,GovernmentTypeId,Power,Ruler")] Empire empire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GovernmentTypeId"] = new SelectList(_context.GovernmentTypes, "Id", "Name", empire.GovernmentTypeId);
            return View(empire);
        }

        // GET: Empires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empire = await _context.Empires.FindAsync(id);
            if (empire == null)
            {
                return NotFound();
            }
            ViewData["GovernmentTypeId"] = new SelectList(_context.GovernmentTypes, "Id", "Name", empire.GovernmentTypeId);
            return View(empire);
        }

        // POST: Empires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,GovernmentTypeId,Power,Ruler")] Empire empire)
        {
            if (id != empire.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpireExists(empire.Id))
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
            ViewData["GovernmentTypeId"] = new SelectList(_context.GovernmentTypes, "Id", "Name", empire.GovernmentTypeId);
            return View(empire);
        }

        // GET: Empires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empire = await _context.Empires
                .Include(e => e.GovernmentType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empire == null)
            {
                return NotFound();
            }

            return View(empire);
        }

        // POST: Empires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empire = await _context.Empires.FindAsync(id);
            _context.Empires.Remove(empire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpireExists(int id)
        {
            return _context.Empires.Any(e => e.Id == id);
        }
    }
}
