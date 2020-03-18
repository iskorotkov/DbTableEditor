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
    public class StarsController : Controller
    {
        private readonly SpaceshipsContext _context;

        public StarsController(SpaceshipsContext context)
        {
            _context = context;
        }

        // GET: Stars
        public async Task<IActionResult> Index()
        {
            var spaceshipsContext = _context.Stars.Include(s => s.Type);
            return View(await spaceshipsContext.ToListAsync());
        }

        // GET: Stars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var star = await _context.Stars
                .Include(s => s.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (star == null)
            {
                return NotFound();
            }

            return View(star);
        }

        // GET: Stars/Create
        public IActionResult Create()
        {
            ViewData["TypeId"] = new SelectList(_context.StarTypes, "Id", "Name");
            return View();
        }

        // POST: Stars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Size,TypeId")] Star star)
        {
            if (ModelState.IsValid)
            {
                _context.Add(star);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeId"] = new SelectList(_context.StarTypes, "Id", "Name", star.TypeId);
            return View(star);
        }

        // GET: Stars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var star = await _context.Stars.FindAsync(id);
            if (star == null)
            {
                return NotFound();
            }
            ViewData["TypeId"] = new SelectList(_context.StarTypes, "Id", "Name", star.TypeId);
            return View(star);
        }

        // POST: Stars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Size,TypeId")] Star star)
        {
            if (id != star.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(star);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StarExists(star.Id))
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
            ViewData["TypeId"] = new SelectList(_context.StarTypes, "Id", "Name", star.TypeId);
            return View(star);
        }

        // GET: Stars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var star = await _context.Stars
                .Include(s => s.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (star == null)
            {
                return NotFound();
            }

            return View(star);
        }

        // POST: Stars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var star = await _context.Stars.FindAsync(id);
            _context.Stars.Remove(star);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StarExists(int id)
        {
            return _context.Stars.Any(e => e.Id == id);
        }
    }
}
