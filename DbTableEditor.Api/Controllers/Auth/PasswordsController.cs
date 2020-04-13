using System.Threading.Tasks;
using DbTableEditor.Auth.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DbTableEditor.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PasswordsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public PasswordsController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Post(PasswordChange change)
        {
            var user = await _userManager.FindByIdAsync(change.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, change.Password);

            if (!result.Succeeded)
            {
                return BadRequest("New password is invalid.");
            }

            return Ok();
        }
    }
}
