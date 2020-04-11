using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbTableEditor.Data.Context;
using DbTableEditor.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbTableEditor.Api.Controllers.Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly SpaceshipsContext _context;

        public StatusesController(SpaceshipsContext context)
        {
            _context = context;
        }

        // GET: api/Statuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatuses()
        {
            return await _context.Statuses.ToListAsync();
        }

        // GET: api/Statuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetStatuses(int id)
        {
            var statuses = await _context.Statuses.FindAsync(id);

            if (statuses == null)
            {
                return NotFound();
            }

            return statuses;
        }

        // PUT: api/Statuses/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatuses(int id, Status statuses)
        {
            if (id != statuses.Id)
            {
                return BadRequest();
            }

            _context.Entry(statuses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusesExists(id))
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

        // POST: api/Statuses
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Status>> PostStatuses(Status statuses)
        {
            _context.Statuses.Add(statuses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatuses", new { id = statuses.Id }, statuses);
        }

        // DELETE: api/Statuses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Status>> DeleteStatuses(int id)
        {
            var statuses = await _context.Statuses.FindAsync(id);
            if (statuses == null)
            {
                return NotFound();
            }

            _context.Statuses.Remove(statuses);
            await _context.SaveChangesAsync();

            return statuses;
        }

        private bool StatusesExists(int id)
        {
            return _context.Statuses.Any(e => e.Id == id);
        }
    }
}
