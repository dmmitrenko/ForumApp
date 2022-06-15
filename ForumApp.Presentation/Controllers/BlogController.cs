using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO;

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

        [HttpGet("{id:guid}", Name = "GetBlogForUser")]
        public IActionResult GetBlogForUser(Guid userId, Guid id)
        {
            var blog = _service.BLogService.GetBlog(userId, id, trackChanges: false);
            return Ok(blog);
        }

        [HttpPost]
        public IActionResult CreateBlogForUser(Guid userId, [FromBody]BlogForCreationDto blog)
        {
            if (blog is null)
                return BadRequest("BlogForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var blogToReturn = _service.BLogService.CreateBlogForUser(userId, blog, trackChanges: false);

            return CreatedAtRoute("GetBlogForUser", new { userId, id = blogToReturn.Id }, blogToReturn);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBlogForUser(Guid userId, Guid id)
        {
            _service.BLogService.DeleteBlogForUser(userId, id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateBlogForUser(Guid userId, Guid id, [FromBody] BlogForUpdateDto blog)
        {
            if (blog is null)
                return BadRequest("BlogForUpdateDto object is null.");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
          
            _service.BLogService.UpdateBlogForUser(userId, id, blog, 
                userTrackChanges: false, blogTrackChanges: true);

            return NoContent();    
        }

        [HttpPatch("{id:guid}")]
        public IActionResult PartiallyUpdateBlogForUser(Guid userId, Guid id, 
            [FromBody]JsonPatchDocument<BlogForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = _service.BLogService.GetBlogForPatch(userId, id, 
                userTrackChanges: false, blogTrackChanges: false);

            patchDoc.ApplyTo(result.blogToPatch, ModelState);

            TryValidateModel(result.blogToPatch);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _service.BLogService.SaveChangesForPatch(result.blogToPatch, result.blogEntity);

            return NoContent();
        }
    }
}
