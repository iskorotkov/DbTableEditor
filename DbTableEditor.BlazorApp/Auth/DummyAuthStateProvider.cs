using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DbTableEditor.BlazorApp.Auth
{
    public class DummyAuthStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(3000);
            var identity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, "John")
            });
            var principal = new ClaimsPrincipal(identity);
            return new AuthenticationState(principal);
        }
    }
}
