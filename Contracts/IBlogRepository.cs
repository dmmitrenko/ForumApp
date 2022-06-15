using Entities.Models;

namespace Contracts
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetBlogsAsync(Guid id, bool trackChanges);
        Task<Blog> GetBlogAsync(Guid userId, Guid id, bool trackChanges);
        void CreateBlogForUser(Guid userId, Blog blog);
        void DeleteBlog(Blog blog);
    }
}
