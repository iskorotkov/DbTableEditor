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
    public class ShipyardsController : ControllerBase
    {
        private readonly SpaceshipsContext _context;

        public ShipyardsController(SpaceshipsContext context)
        {
            _context = context;
        }

        [HttpGet("count")]
        [AllowAnonymous]
        public async Task<ActionResult<int>> Count()
        {
            return await _context.Shipyards.CountAsync();
        }

        // GET: api/Shipyards
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Shipyard>>> GetShipyards()
        {
            return await _context.Shipyards.ToListAsync();
        }

        // GET: api/Shipyards/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Shipyard>> GetShipyard(int id)
        {
            var shipyard = await _context.Shipyards.FindAsync(id);

            if (shipyard == null)
            {
                return NotFound();
            }

            return shipyard;
        }

        // PUT: api/Shipyards/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipyard(int id, Shipyard shipyard)
        {
            if (id != shipyard.Id)
            {
                return BadRequest();
            }

            _context.Entry(shipyard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipyardExists(id))
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

        // POST: api/Shipyards
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Shipyard>> PostShipyard(Shipyard shipyard)
        {
            _context.Shipyards.Add(shipyard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipyard", new { id = shipyard.Id }, shipyard);
        }

        // DELETE: api/Shipyards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shipyard>> DeleteShipyard(int id)
        {
            var shipyard = await _context.Shipyards.FindAsync(id);
            if (shipyard == null)
            {
                return NotFound();
            }

            _context.Shipyards.Remove(shipyard);
            await _context.SaveChangesAsync();

            return shipyard;
        }

        private bool ShipyardExists(int id)
        {
            return _context.Shipyards.Any(e => e.Id == id);
        }
    }
}
