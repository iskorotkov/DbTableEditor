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
    public class AlliancesEntriesController : Controller
    {
        private readonly SpaceshipsContext _context;

        public AlliancesEntriesController(SpaceshipsContext context)
        {
            _context = context;
        }

        // GET: AlliancesEntries
        public async Task<IActionResult> Index()
        {
            var spaceshipsContext = _context.AlliancesEntries.Include(a => a.Alliance).Include(a => a.Empire);
            return View(await spaceshipsContext.ToListAsync());
        }

        // GET: AlliancesEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alliancesEntry = await _context.AlliancesEntries
                .Include(a => a.Alliance)
                .Include(a => a.Empire)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alliancesEntry == null)
            {
                return NotFound();
            }

            return View(alliancesEntry);
        }

        // GET: AlliancesEntries/Create
        public IActionResult Create()
        {
            ViewData["AllianceId"] = new SelectList(_context.Alliances, "Id", "Name");
            ViewData["EmpireId"] = new SelectList(_context.Empires, "Id", "Name");
            return View();
        }

        // POST: AlliancesEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AllianceId,EmpireId,EntryYear")] AlliancesEntry alliancesEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alliancesEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AllianceId"] = new SelectList(_context.Alliances, "Id", "Name", alliancesEntry.AllianceId);
            ViewData["EmpireId"] = new SelectList(_context.Empires, "Id", "Name", alliancesEntry.EmpireId);
            return View(alliancesEntry);
        }

        // GET: AlliancesEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alliancesEntry = await _context.AlliancesEntries.FindAsync(id);
            if (alliancesEntry == null)
            {
                return NotFound();
            }
            ViewData["AllianceId"] = new SelectList(_context.Alliances, "Id", "Name", alliancesEntry.AllianceId);
            ViewData["EmpireId"] = new SelectList(_context.Empires, "Id", "Name", alliancesEntry.EmpireId);
            return View(alliancesEntry);
        }

        // POST: AlliancesEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AllianceId,EmpireId,EntryYear")] AlliancesEntry alliancesEntry)
        {
            if (id != alliancesEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alliancesEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlliancesEntryExists(alliancesEntry.Id))
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
            ViewData["AllianceId"] = new SelectList(_context.Alliances, "Id", "Name", alliancesEntry.AllianceId);
            ViewData["EmpireId"] = new SelectList(_context.Empires, "Id", "Name", alliancesEntry.EmpireId);
            return View(alliancesEntry);
        }

        // GET: AlliancesEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alliancesEntry = await _context.AlliancesEntries
                .Include(a => a.Alliance)
                .Include(a => a.Empire)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alliancesEntry == null)
            {
                return NotFound();
            }

            return View(alliancesEntry);
        }

        // POST: AlliancesEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alliancesEntry = await _context.AlliancesEntries.FindAsync(id);
            _context.AlliancesEntries.Remove(alliancesEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlliancesEntryExists(int id)
        {
            return _context.AlliancesEntries.Any(e => e.Id == id);
        }
    }
}
