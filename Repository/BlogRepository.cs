using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
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
                trackChanges).SingleOrDefaultAsync()!;
        }

        public async Task<IEnumerable<Blog>> GetBlogsAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(b => b.UserId.Equals(id), trackChanges)
                .OrderBy(b => b.Title).ToListAsync();
        }
    }
}
