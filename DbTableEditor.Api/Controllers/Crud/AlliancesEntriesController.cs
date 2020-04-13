using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbTableEditor.Data.Context;
using DbTableEditor.Data.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbTableEditor.Api.Controllers.Crud
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Editor", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AlliancesEntriesController : ControllerBase
    {
        private readonly SpaceshipsContext _context;

        public AlliancesEntriesController(SpaceshipsContext context)
        {
            _context = context;
        }

        // GET: api/AlliancesEntries
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AlliancesEntry>>> GetAlliancesEntries()
        {
            return await _context.AlliancesEntries.ToListAsync();
        }

        // GET: api/AlliancesEntries/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<AlliancesEntry>> GetAlliancesEntry(int id)
        {
            var alliancesEntry = await _context.AlliancesEntries.FindAsync(id);

            if (alliancesEntry == null)
            {
                return NotFound();
            }

            return alliancesEntry;
        }

        // PUT: api/AlliancesEntries/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlliancesEntry(int id, AlliancesEntry alliancesEntry)
        {
            if (id != alliancesEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(alliancesEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlliancesEntryExists(id))
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

        // POST: api/AlliancesEntries
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AlliancesEntry>> PostAlliancesEntry(AlliancesEntry alliancesEntry)
        {
            _context.AlliancesEntries.Add(alliancesEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlliancesEntry", new { id = alliancesEntry.Id }, alliancesEntry);
        }

        // DELETE: api/AlliancesEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AlliancesEntry>> DeleteAlliancesEntry(int id)
        {
            var alliancesEntry = await _context.AlliancesEntries.FindAsync(id);
            if (alliancesEntry == null)
            {
                return NotFound();
            }

            _context.AlliancesEntries.Remove(alliancesEntry);
            await _context.SaveChangesAsync();

            return alliancesEntry;
        }

        private bool AlliancesEntryExists(int id)
        {
            return _context.AlliancesEntries.Any(e => e.Id == id);
        }
    }
}
