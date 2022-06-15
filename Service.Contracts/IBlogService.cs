using Entities.Models;
using Shared.DTO;

namespace Service.Contracts
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogDto>> GetBlogsAsync(Guid userId, bool trackChanges);
        Task<BlogDto> GetBlogAsync(Guid userId, Guid id, bool trackChanges);
        Task<BlogDto> CreateBlogForUserAsync(Guid userId, BlogForCreationDto blogForCreation, bool trackChanges);
        Task DeleteBlogForUserAsync(Guid userId, Guid id, bool trackChanges);
        Task UpdateBlogForUserAsync(Guid userId, Guid id, BlogForUpdateDto blogForUpdate,
            bool userTrackChanges, bool blogTrackChanges);
        Task<(BlogForUpdateDto blogToPatch, Blog blogEntity)> GetBlogForPatchAsync(
            Guid userId, Guid id, bool userTrackChanges, bool blogTrackChanges);
        Task SaveChangesForPatchAsync(BlogForUpdateDto blogToPatch, Blog blogEntity);
    }
}
