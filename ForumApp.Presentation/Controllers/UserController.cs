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
        public IActionResult GetUserCollection(IEnumerable<Guid> ids)
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
    }
}
