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
    public class SpaceshipsController : ControllerBase
    {
        private readonly SpaceshipsContext _context;

        public SpaceshipsController(SpaceshipsContext context)
        {
            _context = context;
        }

        [HttpGet("count")]
        [AllowAnonymous]
        public async Task<ActionResult<int>> Count()
        {
            return await _context.Spaceships.CountAsync();
        }

        [HttpGet("power")]
        [AllowAnonymous]
        public async Task<ActionResult<int>> Power()
        {
            return await _context.Spaceships.SumAsync(x => x.Firepower);
        }

        [HttpGet("mostPowerful")]
        [AllowAnonymous]
        public async Task<ActionResult<Spaceship>> MostPowerful()
        {
            return await _context.Spaceships
                .OrderByDescending(x => x.Firepower)
                .FirstOrDefaultAsync();
        }

        // GET: api/Spaceships
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Spaceship>>> GetSpaceships()
        {
            return await _context.Spaceships.ToListAsync();
        }

        // GET: api/Spaceships/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Spaceship>> GetSpaceship(int id)
        {
            var spaceship = await _context.Spaceships.FindAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            return spaceship;
        }

        // PUT: api/Spaceships/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpaceship(int id, Spaceship spaceship)
        {
            if (id != spaceship.Id)
            {
                return BadRequest();
            }

            _context.Entry(spaceship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpaceshipExists(id))
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

        // POST: api/Spaceships
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Spaceship>> PostSpaceship(Spaceship spaceship)
        {
            _context.Spaceships.Add(spaceship);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpaceship", new { id = spaceship.Id }, spaceship);
        }

        // DELETE: api/Spaceships/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Spaceship>> DeleteSpaceship(int id)
        {
            var spaceship = await _context.Spaceships.FindAsync(id);
            if (spaceship == null)
            {
                return NotFound();
            }

            _context.Spaceships.Remove(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;
        }

        private bool SpaceshipExists(int id)
        {
            return _context.Spaceships.Any(e => e.Id == id);
        }
    }
}
