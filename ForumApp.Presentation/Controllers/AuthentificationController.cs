using ForumApp.Presentation.ActionFilters;
using ForumApp.Service.Interfaces;
using ForumApp.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Presentation.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthentificationController : ControllerBase
{
    private readonly IServiceManager _service;

    public AuthentificationController(IServiceManager service)
    {
        _service = service;
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
    {
        var result = await _service.AuthenticationService.RegisterUser(userForRegistration);

        if(!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }
        
        return StatusCode(201);
    }

    [HttpPost("login")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
    {
        if (!await _service.AuthenticationService.ValidateUser(user))
            return Unauthorized();

        return Ok(new { Token = await _service.AuthenticationService.CreateToken() });
    }
}
