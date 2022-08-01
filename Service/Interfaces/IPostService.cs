using ForumApp.Entities.Responses;
using ForumApp.Shared.DTO;

namespace ForumApp.Service.Interfaces;

public interface IPostService
{
    Task<ApiBaseResponse> GetAllPostsAsync();
    Task<ApiBaseResponse> GetPostAsync(Guid id);
    Task<ApiBaseResponse> CreatePostAsync(PostForCreationDto post);
    Task<ApiBaseResponse> GetByIdsAsync(IEnumerable<Guid> ids);
    Task<ApiBaseResponse> CreatePostCollectionAsync
        (IEnumerable<PostForCreationDto> postCollection);
    Task<ApiBaseResponse> DeletePostAsync(Guid postId);
    Task<ApiBaseResponse> UpdatePostAsync(Guid postId, PostForUpdateDto postForUpdate);
}
