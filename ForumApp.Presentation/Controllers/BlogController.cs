using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace ForumApp.Presentation.Controllers
{
    [Route("api/users/{userId}/blogs")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IServiceManager _service;

        public BlogController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetBlogsForUser(Guid userId)
        {
            var blogs = _service.BLogService.GetBlogs(userId, trackChanges: false);
            return Ok(blogs);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetBlogForUser(Guid userId, Guid id)
        {
            var blog = _service.BLogService.GetBlog(userId, id, trackChanges: false);
            return Ok(blog);
        }
    }
}
