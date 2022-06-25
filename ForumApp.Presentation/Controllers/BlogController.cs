﻿using ForumApp.Presentation.ActionFilters;
using ForumApp.Service.Interfaces;
using ForumApp.Shared.DTO;
using ForumApp.Shared.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ForumApp.Presentation.Controllers;

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
    public async Task<IActionResult> GetBlogsForUser(Guid userId,
        [FromQuery] BlogParameters blogParameters)
    {
        var pagedResult = 
            await _service.BLogService.GetBlogsAsync(userId, blogParameters);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

        return Ok(pagedResult.metaData);
    }

    [HttpGet("{id:guid}", Name = "GetBlogForUser")]
    public async Task<IActionResult> GetBlogForUser(Guid userId, Guid id)
    {
        var blog = 
            await _service.BLogService.GetBlogAsync(userId, id);
        return Ok(blog);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateBlogForUser(Guid userId, [FromBody]BlogForCreationDto blog)
    {
        var blogToReturn = 
            await _service.BLogService.CreateBlogForUserAsync(userId, blog);

        return CreatedAtRoute("GetBlogForUser", new { userId, id = blogToReturn.Id }, blogToReturn);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteBlogForUser(Guid userId, Guid id)
    {
        await _service.BLogService.DeleteBlogForUserAsync(userId, id);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateBlogForUser(Guid userId, Guid id, [FromBody] BlogForUpdateDto blog)
    {
        await _service.BLogService.UpdateBlogForUserAsync(userId, id, blog);

        return NoContent();    
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> PartiallyUpdateBlogForUser(Guid userId, Guid id, 
        [FromBody]JsonPatchDocument<BlogForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var result = await _service.BLogService.GetBlogForPatchAsync(userId, id);

        patchDoc.ApplyTo(result.blogToPatch, ModelState);

        TryValidateModel(result.blogToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.BLogService.SaveChangesForPatchAsync(result.blogToPatch, result.blogEntity);

        return NoContent();
    }
}
