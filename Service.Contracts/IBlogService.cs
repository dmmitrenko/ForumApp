using Shared.DTO;

namespace Service.Contracts
{
    public interface IBlogService
    {
        IEnumerable<BlogDto> GetBlogs(Guid userId, bool trackChanges);
        BlogDto GetBlog(Guid userId, Guid id, bool trackChanges);
        BlogDto CreateBlogForUser(Guid userId, BlogForCreationDto blogForCreation, bool trackChanges);
        void DeleteBlogForUser(Guid userId, Guid id, bool trackChanges);
        void UpdateBlogForUser(Guid userId, Guid id, BlogForUpdateDto blogForUpdate,
            bool userTrackChanges, bool blogTrackChanges);
    }
}
