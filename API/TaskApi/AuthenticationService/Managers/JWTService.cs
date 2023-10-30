using AuthenticationService.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService.Managers
{
    public class JWTService : IAuthService
    {
        public string SecretKey { get; set; }


        public JWTService (string secretKey)
        {
            SecretKey = secretKey;
        }

        private SecurityKey GetSymmetricSecurityKey()
        {
            byte[] symmetricKey = Convert.FromBase64String(SecretKey);
            return new SymmetricSecurityKey(symmetricKey);
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = GetSymmetricSecurityKey()
            };
        }

        

        public string GenerateToken(IAuthContainerModel model)
        {
            if(model == null || model.Claims == null || model.Claims.Length == 0)
            {
                throw new ArgumentException("el Modelo de datos datos de seguridad está vacio");
            }
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor { Subject = new ClaimsIdentity(model.Claims), Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(model.ExpireMinutes)), SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(), model.SecurityAlgorithm) };
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            string token = jwtSecurityTokenHandler.WriteToken(securityToken);
            return token;
        }

        public IEnumerable<Claim> GetTokenClaims(string Token)
        {
            if (string.IsNullOrEmpty(Token))
            {
                throw new ArgumentException("El token ingresado está vacio");
            }

            TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters();
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            try
            {
                ClaimsPrincipal tokenValid = jwtSecurityTokenHandler.ValidateToken(Token, tokenValidationParameters, out SecurityToken tokenValidated);
                return tokenValid.Claims;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsValidToken(string Token)
        {
            bool valReturn = true;

            if(String.IsNullOrEmpty(Token)){
                throw new ArgumentException("El token ingresado esta vacio");
            }

            TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters();
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new ();

            try
            {
                ClaimsPrincipal claimsPrincipal = jwtSecurityTokenHandler.ValidateToken(Token, tokenValidationParameters, out SecurityToken validatedToken);
            }
            catch (Exception)
            {
                valReturn = false;
            }

            return valReturn;
        }
    }
}
