using ForumApp.Entities.Models;
using ForumApp.Shared.RequestFeatures;

namespace ForumApp.Repository.Interfaces;

public interface IBlogRepository
{
    Task<PagedList<Blog>> GetBlogsAsync(Guid id, BlogParameters blogParameters, bool trackChanges);
    Task<Blog> GetBlogAsync(Guid userId, Guid id, bool trackChanges);
    void CreateBlogForUser(Guid userId, Blog blog);
    void DeleteBlog(Blog blog);
}
