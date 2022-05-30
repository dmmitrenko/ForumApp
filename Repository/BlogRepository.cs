using Contracts;
using Entities.Models;

namespace Repository
{
    public class BlogRepository : RepositoryBase<Blog>, IBlogRepository
    {
        public BlogRepository(RepositoryContext context) : base(context)
        {
        }

        public Blog GetBlog(Guid userId, Guid id, bool trackChanges)
        {
            return FindByCondition(item => item.UserId.Equals(userId) && item.Id.Equals(id),
                trackChanges).SingleOrDefault()!;
        }

        public IEnumerable<Blog> GetBlogs(Guid id, bool trackChanges)
        {
            return FindByCondition(b => b.UserId.Equals(id), trackChanges)
                .OrderBy(b => b.Title).ToList();
        }
    }
}
