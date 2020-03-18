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
    public class GovernmentTypesController : Controller
    {
        private readonly SpaceshipsContext _context;

        public GovernmentTypesController(SpaceshipsContext context)
        {
            _context = context;
        }

        // GET: GovernmentTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GovernmentTypes.ToListAsync());
        }

        // GET: GovernmentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var governmentType = await _context.GovernmentTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (governmentType == null)
            {
                return NotFound();
            }

            return View(governmentType);
        }

        // GET: GovernmentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GovernmentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] GovernmentType governmentType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(governmentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(governmentType);
        }

        // GET: GovernmentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var governmentType = await _context.GovernmentTypes.FindAsync(id);
            if (governmentType == null)
            {
                return NotFound();
            }
            return View(governmentType);
        }

        // POST: GovernmentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] GovernmentType governmentType)
        {
            if (id != governmentType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(governmentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GovernmentTypeExists(governmentType.Id))
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
            return View(governmentType);
        }

        // GET: GovernmentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var governmentType = await _context.GovernmentTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (governmentType == null)
            {
                return NotFound();
            }

            return View(governmentType);
        }

        // POST: GovernmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var governmentType = await _context.GovernmentTypes.FindAsync(id);
            _context.GovernmentTypes.Remove(governmentType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GovernmentTypeExists(int id)
        {
            return _context.GovernmentTypes.Any(e => e.Id == id);
        }
    }
}
