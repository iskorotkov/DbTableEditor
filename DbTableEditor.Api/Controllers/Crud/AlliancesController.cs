using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbTableEditor.Data.Context;
using DbTableEditor.Data.Model;
using DbTableEditor.Data.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbTableEditor.Api.Controllers.Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlliancesController : ControllerBase
    {
        private readonly SpaceshipsContext _context;

        public AlliancesController(SpaceshipsContext context)
        {
            _context = context;
        }

        // GET: api/Alliances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alliance>>> GetAlliances()
        {
            return await _context.Alliances.ToListAsync();
        }

        [HttpGet("status")]
        public async Task<ActionResult<IEnumerable<AllianceStatus>>> GetAlliancesStatus()
        {
            return await _context.Alliances
                .Select(a => new AllianceStatus(a, a.AlliancesEntries.Count > 0))
                .ToListAsync();
        }

        // GET: api/Alliances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alliance>> GetAlliance(int id)
        {
            var alliance = await _context.Alliances.FindAsync(id);

            if (alliance == null)
            {
                return NotFound();
            }

            return alliance;
        }

        // PUT: api/Alliances/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlliance(int id, Alliance alliance)
        {
            if (id != alliance.Id)
            {
                return BadRequest();
            }

            _context.Entry(alliance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllianceExists(id))
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

        // POST: api/Alliances
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Alliance>> PostAlliance(Alliance alliance)
        {
            _context.Alliances.Add(alliance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlliance", new { id = alliance.Id }, alliance);
        }

        // DELETE: api/Alliances/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Alliance>> DeleteAlliance(int id)
        {
            var alliance = await _context.Alliances.FindAsync(id);
            if (alliance == null)
            {
                return NotFound();
            }

            _context.Alliances.Remove(alliance);
            await _context.SaveChangesAsync();

            return alliance;
        }

        private bool AllianceExists(int id)
        {
            return _context.Alliances.Any(e => e.Id == id);
        }
    }
}
