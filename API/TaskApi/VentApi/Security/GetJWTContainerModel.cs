using AuthenticationService.Managers;
using AuthenticationService.Models;
using System.Collections.Generic;
using System;
using System.Security.Claims;
using System.Linq;

namespace TaskApi.Security
{
    internal class GetJWTContainerModel
    {

        private IAuthContainerModel _authContainerModel;

        public GetJWTContainerModel(IAuthContainerModel authContainerModel)
        {
            _authContainerModel = authContainerModel;
        }

        private static JWTContainerModel BuildContainerModel( string user, string email)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, user),
                    new Claim(ClaimTypes.Email, email)
                }
            };
        }

        public string GenerateToken()
        {
            IAuthContainerModel model = new JWTContainerModel() { Claims = _authContainerModel.BuildClaims("maurice", "951mauricetriana@gmail.com") };
            IAuthService authService = new JWTService(model.SecretKey);

            string token = authService.GenerateToken(model);

            return token;
        }

        public static bool ValidateToken(string token)
        {
            IAuthContainerModel model = BuildContainerModel("maurice", "951mauricetriana@gmail.com");
            IAuthService authService = new JWTService(model.SecretKey);
            bool isValid = false;

            if (!authService.IsValidToken(token))
            {
                throw new UnauthorizedAccessException();
            }
            else
            {
                List<Claim> claims = authService.GetTokenClaims(token).ToList();
                isValid = claims.Any(x => x.Type == ClaimTypes.Name && x.Value == "maurice");
            }

            return isValid;
        }
    }
}
