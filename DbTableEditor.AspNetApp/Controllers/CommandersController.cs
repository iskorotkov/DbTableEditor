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
    public class CommandersController : Controller
    {
        private readonly SpaceshipsContext _context;

        public CommandersController(SpaceshipsContext context)
        {
            _context = context;
        }

        // GET: Commanders
        public async Task<IActionResult> Index()
        {
            var spaceshipsContext = _context.Commanders.Include(c => c.Rank);
            return View(await spaceshipsContext.ToListAsync());
        }

        // GET: Commanders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commander = await _context.Commanders
                .Include(c => c.Rank)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commander == null)
            {
                return NotFound();
            }

            return View(commander);
        }

        // GET: Commanders/Create
        public IActionResult Create()
        {
            ViewData["RankId"] = new SelectList(_context.Ranks, "Id", "Name");
            return View();
        }

        // POST: Commanders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,Age,RankId,Skill")] Commander commander)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commander);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RankId"] = new SelectList(_context.Ranks, "Id", "Name", commander.RankId);
            return View(commander);
        }

        // GET: Commanders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commander = await _context.Commanders.FindAsync(id);
            if (commander == null)
            {
                return NotFound();
            }
            ViewData["RankId"] = new SelectList(_context.Ranks, "Id", "Name", commander.RankId);
            return View(commander);
        }

        // POST: Commanders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender,Age,RankId,Skill")] Commander commander)
        {
            if (id != commander.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commander);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommanderExists(commander.Id))
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
            ViewData["RankId"] = new SelectList(_context.Ranks, "Id", "Name", commander.RankId);
            return View(commander);
        }

        // GET: Commanders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commander = await _context.Commanders
                .Include(c => c.Rank)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commander == null)
            {
                return NotFound();
            }

            return View(commander);
        }

        // POST: Commanders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commander = await _context.Commanders.FindAsync(id);
            _context.Commanders.Remove(commander);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommanderExists(int id)
        {
            return _context.Commanders.Any(e => e.Id == id);
        }
    }
}
