using ForumApp.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO;

namespace ForumApp.Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _service;

        public UserController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _service.UserService.GetAllUsers(trackChanges: false);

            return Ok(users);
        }

        [HttpGet("{id:guid}", Name = "UserById")]
        public IActionResult GetUser(Guid id)
        {
            var user = _service.UserService.GetUser(id, trackChanges: false);
            
            return Ok(user);
        }

        [HttpGet("collection/({ids})", Name = "UserCollection")]
        public IActionResult GetUserCollection([ModelBinder(BinderType =
            typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            var users = _service.UserService.GetByIds(ids, trackChanges: false);

            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserForCreationDto user)
        {
            if (user is null)
                return BadRequest("UserForCreationDto object is null");

            var createdUser = _service.UserService.CreateUser(user);

            return CreatedAtRoute("UserById", new { id = createdUser.Id }, createdUser);
        }

        [HttpPost("collection")]
        public IActionResult CreateUserCollection([FromBody] IEnumerable<UserForCreationDto> userCollection)
        {
            var result = _service.UserService.CreateUserCollection(userCollection);

            return CreatedAtRoute("UserCollection", new {result.ids}, result.users);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteUser(Guid id)
        {
            _service.UserService.DeleteUser(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateUser(Guid id, [FromBody] UserForUpdateDto user)
        {
            if (user is null)
                return BadRequest("UserForUpdateDto object is null");

            _service.UserService.UpdateUser(id, user, trackChanges: true);

            return NoContent();
        }
    }
}
