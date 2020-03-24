using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbTableEditor.Data.Context;
using DbTableEditor.Data.Model;

namespace DbTableEditor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpiresController : ControllerBase
    {
        private readonly SpaceshipsContext _context;

        public EmpiresController(SpaceshipsContext context)
        {
            _context = context;
        }

        // GET: api/Empires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empire>>> GetEmpires()
        {
            return await _context.Empires.ToListAsync();
        }

        // GET: api/Empires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empire>> GetEmpire(int id)
        {
            var empire = await _context.Empires.FindAsync(id);

            if (empire == null)
            {
                return NotFound();
            }

            return empire;
        }

        // PUT: api/Empires/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpire(int id, Empire empire)
        {
            if (id != empire.Id)
            {
                return BadRequest();
            }

            _context.Entry(empire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpireExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Empires
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Empire>> PostEmpire(Empire empire)
        {
            _context.Empires.Add(empire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpire", new { id = empire.Id }, empire);
        }

        // DELETE: api/Empires/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Empire>> DeleteEmpire(int id)
        {
            var empire = await _context.Empires.FindAsync(id);
            if (empire == null)
            {
                return NotFound();
            }

            _context.Empires.Remove(empire);
            await _context.SaveChangesAsync();

            return empire;
        }

        private bool EmpireExists(int id)
        {
            return _context.Empires.Any(e => e.Id == id);
        }
    }
}
