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
    public class GovernmentTypesController : ControllerBase
    {
        private readonly SpaceshipsContext _context;

        public GovernmentTypesController(SpaceshipsContext context)
        {
            _context = context;
        }

        // GET: api/GovernmentTypes
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<GovernmentType>>> GetGovernmentTypes()
        {
            return await _context.GovernmentTypes.ToListAsync();
        }

        // GET: api/GovernmentTypes/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GovernmentType>> GetGovernmentType(int id)
        {
            var governmentType = await _context.GovernmentTypes.FindAsync(id);

            if (governmentType == null)
            {
                return NotFound();
            }

            return governmentType;
        }

        // PUT: api/GovernmentTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGovernmentType(int id, GovernmentType governmentType)
        {
            if (id != governmentType.Id)
            {
                return BadRequest();
            }

            _context.Entry(governmentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GovernmentTypeExists(id))
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

        // POST: api/GovernmentTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GovernmentType>> PostGovernmentType(GovernmentType governmentType)
        {
            _context.GovernmentTypes.Add(governmentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGovernmentType", new { id = governmentType.Id }, governmentType);
        }

        // DELETE: api/GovernmentTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GovernmentType>> DeleteGovernmentType(int id)
        {
            var governmentType = await _context.GovernmentTypes.FindAsync(id);
            if (governmentType == null)
            {
                return NotFound();
            }

            _context.GovernmentTypes.Remove(governmentType);
            await _context.SaveChangesAsync();

            return governmentType;
        }

        private bool GovernmentTypeExists(int id)
        {
            return _context.GovernmentTypes.Any(e => e.Id == id);
        }
    }
}
