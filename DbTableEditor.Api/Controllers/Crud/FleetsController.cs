using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbTableEditor.Data.Context;
using DbTableEditor.Data.Model;
using DbTableEditor.Data.Wrappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbTableEditor.Api.Controllers.Crud
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Editor", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FleetsController : ControllerBase
    {
        private readonly SpaceshipsContext _context;

        public FleetsController(SpaceshipsContext context)
        {
            _context = context;
        }

        [HttpGet("count")]
        [AllowAnonymous]
        public async Task<ActionResult<int>> Count()
        {
            return await _context.Fleets.CountAsync();
        }

        [HttpGet("operational")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<FleetOperational>>> GetOperationalFleets()
        {
            var fleets = await _context.Fleets
                .Include(f => f.Spaceships)
                .ToListAsync();
            var result = fleets
                .Select(f => new FleetOperational(f, f.Spaceships.Count > 0))
                .ToList();
            foreach (var entry in result)
            {
                entry.Fleet.Spaceships = null;
            }
            return result;
        }

        // GET: api/Fleets
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Fleet>>> GetFleets()
        {
            return await _context.Fleets.ToListAsync();
        }

        // GET: api/Fleets/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Fleet>> GetFleet(int id)
        {
            var fleet = await _context.Fleets.FindAsync(id);

            if (fleet == null)
            {
                return NotFound();
            }

            return fleet;
        }

        // PUT: api/Fleets/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFleet(int id, Fleet fleet)
        {
            if (id != fleet.Id)
            {
                return BadRequest();
            }

            _context.Entry(fleet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FleetExists(id))
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

        // POST: api/Fleets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Fleet>> PostFleet(Fleet fleet)
        {
            _context.Fleets.Add(fleet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFleet", new { id = fleet.Id }, fleet);
        }

        // DELETE: api/Fleets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fleet>> DeleteFleet(int id)
        {
            var fleet = await _context.Fleets.FindAsync(id);
            if (fleet == null)
            {
                return NotFound();
            }

            _context.Fleets.Remove(fleet);
            await _context.SaveChangesAsync();

            return fleet;
        }

        private bool FleetExists(int id)
        {
            return _context.Fleets.Any(e => e.Id == id);
        }
    }
}
