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
    public class CommandersController : ControllerBase
    {
        private readonly SpaceshipsContext _context;

        public CommandersController(SpaceshipsContext context)
        {
            _context = context;
        }

        // GET: api/Commanders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commander>>> GetCommanders()
        {
            return await _context.Commanders.ToListAsync();
        }

        // GET: api/Commanders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commander>> GetCommander(int id)
        {
            var commander = await _context.Commanders.FindAsync(id);

            if (commander == null)
            {
                return NotFound();
            }

            return commander;
        }

        // PUT: api/Commanders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommander(int id, Commander commander)
        {
            if (id != commander.Id)
            {
                return BadRequest();
            }

            _context.Entry(commander).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommanderExists(id))
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

        // POST: api/Commanders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Commander>> PostCommander(Commander commander)
        {
            _context.Commanders.Add(commander);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommander", new { id = commander.Id }, commander);
        }

        // DELETE: api/Commanders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Commander>> DeleteCommander(int id)
        {
            var commander = await _context.Commanders.FindAsync(id);
            if (commander == null)
            {
                return NotFound();
            }

            _context.Commanders.Remove(commander);
            await _context.SaveChangesAsync();

            return commander;
        }

        private bool CommanderExists(int id)
        {
            return _context.Commanders.Any(e => e.Id == id);
        }
    }
}
