using ForumApp.Entities.Models;
using ForumApp.Shared.DTO;
using ForumApp.Shared.RequestFeatures;

namespace ForumApp.Service.Interfaces
{
    public interface IBlogService
    {
        Task<(IEnumerable<BlogDto> blogs, MetaData metaData)> GetBlogsAsync(Guid userId, BlogParameters blogParameters);
        Task<BlogDto> GetBlogAsync(Guid userId, Guid id);
        Task<BlogDto> CreateBlogForUserAsync(Guid userId, BlogForCreationDto blogForCreation);
        Task DeleteBlogForUserAsync(Guid userId, Guid id);
        Task UpdateBlogForUserAsync(Guid userId, Guid id, BlogForUpdateDto blogForUpdate);
        Task<(BlogForUpdateDto blogToPatch, Blog blogEntity)> GetBlogForPatchAsync(
            Guid userId, Guid id);
        Task SaveChangesForPatchAsync(BlogForUpdateDto blogToPatch, Blog blogEntity);
    }
}
