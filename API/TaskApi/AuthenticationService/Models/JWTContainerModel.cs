using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService.Models
{
    public class JWTContainerModel : IAuthContainerModel
    {
        public string SecretKey { get; set; } = "]98xC3!sT-HQ";
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;
        public int ExpireMinutes { get; set; } = 10080;
        public Claim[] Claims { get; set; }

        public Claim[] BuildClaims(string name, string email)
        {
            return new Claim[]
            {
                new Claim (ClaimTypes.Name, name),
                new Claim (ClaimTypes.Email, email)
            };
        }
    }
}
