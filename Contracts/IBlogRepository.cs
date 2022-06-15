using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IBlogRepository
    {
        Task<PagedList<Blog>> GetBlogsAsync(Guid id, BlogParameters blogParameters, bool trackChanges);
        Task<Blog> GetBlogAsync(Guid userId, Guid id, bool trackChanges);
        void CreateBlogForUser(Guid userId, Blog blog);
        void DeleteBlog(Blog blog);
    }
}
