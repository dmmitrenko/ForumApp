using ForumApp.Presentation.ActionFilters;
using ForumApp.Presentation.ModelBinders;
using ForumApp.Service.Interfaces;
using ForumApp.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Presentation.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IServiceManager _service;

    public UserController(IServiceManager service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = 
            await _service.UserService.GetAllUsersAsync(trackChanges: false);

        return Ok(users);
    }

    [HttpGet("{id:guid}", Name = "UserById")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var user = await _service.UserService.GetUserAsync(id, trackChanges: false);
        
        return Ok(user);
    }

    [HttpGet("collection/({ids})", Name = "UserCollection")]
    public async Task<IActionResult> GetUserCollection([ModelBinder(BinderType =
        typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
    {
        var users = 
            await _service.UserService.GetByIdsAsync(ids, trackChanges: false);

        return Ok(users);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateUser([FromBody] UserForCreationDto user)
    {
        var createdUser = await _service.UserService.CreateUserAsync(user);

        return CreatedAtRoute("UserById", new { id = createdUser.Id }, createdUser);
    }

    [HttpPost("collection")]
    public async Task<IActionResult> CreateUserCollection([FromBody] IEnumerable<UserForCreationDto> userCollection)
    {
        var result = 
            await _service.UserService.CreateUserCollectionAsync(userCollection);

        return CreatedAtRoute("UserCollection", new {result.ids}, result.users);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await _service.UserService.DeleteUserAsync(id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserForUpdateDto user)
    {
        await _service.UserService.UpdateUserAsync(id, user, trackChanges: true);

        return NoContent();
    }
}
