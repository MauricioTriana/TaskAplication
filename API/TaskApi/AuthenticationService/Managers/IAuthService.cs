using AuthenticationService.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace AuthenticationService.Managers
{
    public interface IAuthService
    {
        string SecretKey { get; set; }

        bool IsValidToken(string Token);

        string GenerateToken(IAuthContainerModel model);

        IEnumerable<Claim> GetTokenClaims(string Token);

    }
}
