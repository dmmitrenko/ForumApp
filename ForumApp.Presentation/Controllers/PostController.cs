using ForumApp.Entities.Responses;
using ForumApp.Presentation.ActionFilters;
using ForumApp.Presentation.Extensions;
using ForumApp.Presentation.ModelBinders;
using ForumApp.Service.Interfaces;
using ForumApp.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Presentation.Controllers;

[Route("api/posts")]
[ApiController]
public class PostController : ApiControllerBase
{
    private readonly IServiceManager _service;

    public PostController(IServiceManager service)
    {
        _service = service;
    }


    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetPosts()
    {
        var baseResult = 
            await _service.PostService.GetAllPostsAsync();

        if (!baseResult.Success)
            return ProcessError(baseResult);

        var posts = baseResult.GetResult<IEnumerable<PostDto>>();

        return Ok(posts);
    }

    [HttpGet("{id:guid}", Name = "PostById")]
    public async Task<IActionResult> GetPost(Guid id)
    {
        var baseResult = await _service.PostService.GetPostAsync(id);

        if(!baseResult.Success)
            return ProcessError(baseResult);

        var post = baseResult.GetResult<PostDto>();
        
        return Ok(post);
    }

    [HttpGet("collection/({ids})", Name = "PostCollection")]
    public async Task<IActionResult> GetPostCollection([ModelBinder(BinderType =
        typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
    {
        var baseResult = 
            await _service.PostService.GetByIdsAsync(ids);

        if (!baseResult.Success)
            return ProcessError(baseResult);

        var posts = baseResult.GetResult<IEnumerable<PostDto>>();

        return Ok(posts);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreatePost([FromBody] PostForCreationDto post)
    {
        var baseResult = await _service.PostService.CreatePostAsync(post);

        if (!baseResult.Success)
            return ProcessError(baseResult);

        var postResult = baseResult.GetResult<PostDto>();

        return Created("PostById", postResult);
    }

    [HttpPost("collection")]
    public async Task<IActionResult> CreatePostCollection([FromBody] IEnumerable<PostForCreationDto> postCollection)
    {
        var baseResult = 
            await _service.PostService.CreatePostCollectionAsync(postCollection);

        if (!baseResult.Success)
            return ProcessError(baseResult);

        var postResult = baseResult.GetResult<(IEnumerable<PostDto> posts, string ids)>();

        return Created("PostCollection", postResult);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePost(Guid id)
    {
        var baseResult = await _service.PostService.DeletePostAsync(id);

        if (!baseResult.Success)
            return ProcessError(baseResult);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdatePost(Guid id, [FromBody] PostForUpdateDto post)
    {
        var baseResult = await _service.PostService.UpdatePostAsync(id, post);

        if (!baseResult.Success)
            return ProcessError(baseResult);

        var updatedPost = baseResult.GetResult<PostDto>();

        return Ok(updatedPost);
    }
}
