using ForumApp.Entities.Responses;
using ForumApp.Shared.DTO;

namespace ForumApp.Service.Interfaces;

public interface IPostService
{
    Task<IEnumerable<PostDto>> GetAllPostsAsync();
    Task<ApiBaseResponse> GetPostAsync(Guid id);
    Task<PostDto> CreatePostAsync(PostForCreationDto post);
    Task<IEnumerable<PostDto>> GetByIdsAsync(IEnumerable<Guid> ids);
    Task<(IEnumerable<PostDto> posts, string ids)> CreatePostCollectionAsync
        (IEnumerable<PostForCreationDto> postCollection);
    Task DeletePostAsync(Guid postId);
    Task UpdatePostAsync(Guid postId, PostForUpdateDto postForUpdate);
}
