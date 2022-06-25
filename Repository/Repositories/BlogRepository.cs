using ForumApp.Entities.Models;
using ForumApp.Repository.Interfaces;
using ForumApp.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Repository.Repositories;

public class BlogRepository : RepositoryBase<Blog>, IBlogRepository
{
    public BlogRepository(RepositoryContext context) : base(context)
    {
    }

    public void CreateBlogForUser(Guid userId, Blog blog)
    {
        blog.UserId = userId;
        Create(blog);
    }

    public void DeleteBlog(Blog blog) => Delete(blog);


    public async Task<Blog> GetBlogAsync(Guid userId, Guid id, bool trackChanges)
    {
        return await FindByCondition(item => item.UserId.Equals(userId) && item.Id.Equals(id),
            trackChanges).SingleOrDefaultAsync();
    }

    public async Task<PagedList<Blog>> GetBlogsAsync(Guid id, BlogParameters blogParameters, bool trackChanges)
    {
        var blogs = await FindByCondition(b => b.UserId.Equals(id), trackChanges)
            .OrderBy(b => b.Title)
            .Skip((blogParameters.PageNumber - 1) * blogParameters.PageSize)
            .Take(blogParameters.PageSize)
            .ToListAsync();

        var count = await FindByCondition(n => n.UserId.Equals(id), trackChanges)
            .CountAsync();

        return new PagedList<Blog>(blogs, count,
            blogParameters.PageNumber, blogParameters.PageSize);
    }
}
