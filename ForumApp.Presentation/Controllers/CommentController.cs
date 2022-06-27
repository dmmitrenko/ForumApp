using ForumApp.Presentation.ActionFilters;
using ForumApp.Service.Interfaces;
using ForumApp.Shared.DTO;
using ForumApp.Shared.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ForumApp.Presentation.Controllers;

[Route("api/users/{userId}/blogs")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly IServiceManager _service;

    public CommentController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetCommentsForPost(Guid postId,
        [FromQuery] CommentParameters commentParameters)
    {
        var pagedResult = 
            await _service.CommentService.GetCommentsAsync(postId, commentParameters);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

        return Ok(pagedResult.metaData);
    }

    [HttpGet("{id:guid}", Name = "GetBlogForUser")]
    public async Task<IActionResult> GetCommentForPost(Guid postId, Guid id)
    {
        var comment = 
            await _service.CommentService.GetCommentAsync(postId, id);
        return Ok(comment);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCommentForPost(Guid postId, [FromBody]CommentForCreationDto comment)
    {
        var commentToReturn = 
            await _service.CommentService.CreateCommentForPostAsync(postId, comment);

        return CreatedAtRoute("GetCommentForPost", new { postId, id = commentToReturn.Id }, commentToReturn);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCommentForPost(Guid postId, Guid id)
    {
        await _service.CommentService.DeleteCommentForPostAsync(postId, id);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateCommentForPost(Guid postId, Guid id, [FromBody] CommentForUpdateDto comment)
    {
        await _service.CommentService.UpdateCommentForPostAsync(postId, id, comment);

        return NoContent();    
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> PartiallyUpdateCommentForPost(Guid postId, Guid id, 
        [FromBody]JsonPatchDocument<CommentForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var result = await _service.CommentService.GetCommentForPatchAsync(postId, id);

        patchDoc.ApplyTo(result.commentToPatch, ModelState);

        TryValidateModel(result.commentToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.CommentService.SaveChangesForPatchAsync(result.commentToPatch, result.commentEntity);

        return NoContent();
    }
}
