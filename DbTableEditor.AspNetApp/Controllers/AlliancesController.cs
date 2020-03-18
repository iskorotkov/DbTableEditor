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
    public class AlliancesController : Controller
    {
        private readonly SpaceshipsContext _context;

        public AlliancesController(SpaceshipsContext context)
        {
            _context = context;
        }

        // GET: Alliances
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alliances.ToListAsync());
        }

        // GET: Alliances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alliance = await _context.Alliances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alliance == null)
            {
                return NotFound();
            }

            return View(alliance);
        }

        // GET: Alliances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alliances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Power")] Alliance alliance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alliance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alliance);
        }

        // GET: Alliances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alliance = await _context.Alliances.FindAsync(id);
            if (alliance == null)
            {
                return NotFound();
            }
            return View(alliance);
        }

        // POST: Alliances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Power")] Alliance alliance)
        {
            if (id != alliance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alliance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllianceExists(alliance.Id))
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
            return View(alliance);
        }

        // GET: Alliances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alliance = await _context.Alliances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alliance == null)
            {
                return NotFound();
            }

            return View(alliance);
        }

        // POST: Alliances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alliance = await _context.Alliances.FindAsync(id);
            _context.Alliances.Remove(alliance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllianceExists(int id)
        {
            return _context.Alliances.Any(e => e.Id == id);
        }
    }
}
