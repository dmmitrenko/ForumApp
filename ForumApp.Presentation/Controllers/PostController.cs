using ForumApp.Presentation.ActionFilters;
using ForumApp.Presentation.ModelBinders;
using ForumApp.Service.Interfaces;
using ForumApp.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Presentation.Controllers;

[Route("api/posts")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IServiceManager _service;

    public PostController(IServiceManager service) => _service = service;

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetPosts()
    {
        var posts = 
            await _service.PostService.GetAllPostsAsync();

        return Ok(posts);
    }

    [HttpGet("{id:guid}", Name = "PostById")]
    public async Task<IActionResult> GetPost(Guid id)
    {
        var post = await _service.PostService.GetPostAsync(id);
        
        return Ok(post);
    }

    [HttpGet("collection/({ids})", Name = "PostCollection")]
    public async Task<IActionResult> GetPostCollection([ModelBinder(BinderType =
        typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
    {
        var posts = 
            await _service.PostService.GetByIdsAsync(ids);

        return Ok(posts);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreatePost([FromBody] PostForCreationDto post)
    {
        var createdPost = await _service.PostService.CreatePostAsync(post);

        return CreatedAtRoute("PostById", new { id = createdPost.Id }, createdPost);
    }

    [HttpPost("collection")]
    public async Task<IActionResult> CreatePostCollection([FromBody] IEnumerable<PostForCreationDto> postCollection)
    {
        var result = 
            await _service.PostService.CreatePostCollectionAsync(postCollection);

        return CreatedAtRoute("PostCollection", new {result.ids}, result.posts);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePost(Guid id)
    {
        await _service.PostService.DeletePostAsync(id);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdatePost(Guid id, [FromBody] PostForUpdateDto post)
    {
        await _service.PostService.UpdatePostAsync(id, post);

        return NoContent();
    }
}
