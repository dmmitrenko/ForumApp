﻿using Microsoft.AspNetCore.JsonPatch;
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
        public async Task<IActionResult> GetBlogsForUser(Guid userId)
        {
            var blogs = 
                await _service.BLogService.GetBlogsAsync(userId, trackChanges: false);
            return Ok(blogs);
        }

        [HttpGet("{id:guid}", Name = "GetBlogForUser")]
        public async Task<IActionResult> GetBlogForUser(Guid userId, Guid id)
        {
            var blog = 
                await _service.BLogService.GetBlogAsync(userId, id, trackChanges: false);
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogForUser(Guid userId, [FromBody]BlogForCreationDto blog)
        {
            if (blog is null)
                return BadRequest("BlogForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var blogToReturn = 
                await _service.BLogService.CreateBlogForUserAsync(userId, blog, trackChanges: false);

            return CreatedAtRoute("GetBlogForUser", new { userId, id = blogToReturn.Id }, blogToReturn);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBlogForUser(Guid userId, Guid id)
        {
            await _service.BLogService.DeleteBlogForUserAsync(userId, id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBlogForUser(Guid userId, Guid id, [FromBody] BlogForUpdateDto blog)
        {
            if (blog is null)
                return BadRequest("BlogForUpdateDto object is null.");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
          
            await _service.BLogService.UpdateBlogForUserAsync(userId, id, blog, 
                userTrackChanges: false, blogTrackChanges: true);

            return NoContent();    
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateBlogForUser(Guid userId, Guid id, 
            [FromBody]JsonPatchDocument<BlogForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = await _service.BLogService.GetBlogForPatchAsync(userId, id, 
                userTrackChanges: false, blogTrackChanges: false);

            patchDoc.ApplyTo(result.blogToPatch, ModelState);

            TryValidateModel(result.blogToPatch);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.BLogService.SaveChangesForPatchAsync(result.blogToPatch, result.blogEntity);

            return NoContent();
        }
    }
}
