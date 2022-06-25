using ForumApp.Entities.Models;
using ForumApp.Shared.DTO;
using ForumApp.Shared.RequestFeatures;

namespace ForumApp.Service.Interfaces;

public interface IBlogService
{
    Task<(IEnumerable<BlogDto> blogs, MetaData metaData)> GetBlogsAsync(Guid userId, BlogParameters blogParameters, bool trackChanges);
    Task<BlogDto> GetBlogAsync(Guid userId, Guid id, bool trackChanges);
    Task<BlogDto> CreateBlogForUserAsync(Guid userId, BlogForCreationDto blogForCreation, bool trackChanges);
    Task DeleteBlogForUserAsync(Guid userId, Guid id, bool trackChanges);
    Task UpdateBlogForUserAsync(Guid userId, Guid id, BlogForUpdateDto blogForUpdate,
        bool userTrackChanges, bool blogTrackChanges);
    Task<(BlogForUpdateDto blogToPatch, Blog blogEntity)> GetBlogForPatchAsync(
        Guid userId, Guid id, bool userTrackChanges, bool blogTrackChanges);
    Task SaveChangesForPatchAsync(BlogForUpdateDto blogToPatch, Blog blogEntity);
}
