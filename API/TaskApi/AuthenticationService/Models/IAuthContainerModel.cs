using System.Security.Claims;

namespace AuthenticationService.Models
{
    public interface IAuthContainerModel
    {
        #region Members
        string SecretKey { get; set; }
        string SecurityAlgorithm { get; set; }
        int ExpireMinutes { get; set; }

        Claim [] Claims { get; set; }

        Claim[] BuildClaims(string name, string email);
        #endregion
    }
}
