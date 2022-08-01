using ForumApp.Shared.DTO;
using Microsoft.AspNetCore.Identity;

namespace ForumApp.Service.Interfaces;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);
    Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
    Task<string> CreateToken();
}
