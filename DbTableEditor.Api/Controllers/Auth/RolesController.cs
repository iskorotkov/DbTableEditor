using System.Threading.Tasks;
using DbTableEditor.Auth.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DbTableEditor.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RolesController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(RoleChange change)
        {
            var user = await _userManager.FindByIdAsync(change.UserId);
            if (user == null)
            {
                return NotFound();
            }

            await _userManager.AddToRoleAsync(user, change.Role);
            return Ok();
        }

        [HttpPost("remove")]
        public async Task<ActionResult> Remove(RoleChange change)
        {
            var user = await _userManager.FindByIdAsync(change.UserId);
            if (user == null)
            {
                return NotFound();
            }

            await _userManager.RemoveFromRoleAsync(user, change.Role);
            return Ok();
        }
    }
}
