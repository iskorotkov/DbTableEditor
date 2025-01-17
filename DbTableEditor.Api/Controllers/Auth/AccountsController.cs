﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DbTableEditor.Auth.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DbTableEditor.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountsController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RolesController _rolesController;

        public AccountsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            RolesController rolesController)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _rolesController = rolesController;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserCredentials model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var role = new RoleChange
                {
                    UserId = user.Id,
                    Role = model.Role
                };
                await _rolesController.Add(role);

                return await BuildToken(model);
            }

            return BadRequest("Username or password is invalid");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserCredentials userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email,
                userInfo.Password, false, false);
            if (result.Succeeded)
            {
                return await BuildToken(userInfo);
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfo>>> GetUsers()
        {
            var users = await _userManager.Users
                .ToListAsync();

            var userInfo = new List<UserInfo>();
            foreach (var identityUser in users)
            {
                userInfo.Add(await CreateUserFromIdentity(identityUser));
            }

            return Ok(userInfo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserInfo>> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userManager.DeleteAsync(user);
            return await CreateUserFromIdentity(user);
        }

        private async Task<UserInfo> CreateUserFromIdentity(IdentityUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            return new UserInfo
            {
                Id = user.Id,
                Username = user.UserName,
                Roles = roles.ToList()
            };
        }

        private async Task<UserToken> BuildToken(UserCredentials userInfo)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim(ClaimTypes.Name, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var user = await _userManager.FindByNameAsync(userInfo.Email);
            claims.AddRange(from role in await _userManager.GetRolesAsync(user)
                select new Claim(ClaimTypes.Role, role));

            var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey ?? throw new ArgumentException("JWT key wasn't provided by environment.")));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);

            var token = new JwtSecurityToken(
                claims: claims, expires: expiration, signingCredentials: credentials);

            return new UserToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
