using Contracts;
using Entities.Models;

namespace Repository
{
    public class BlogRepository : RepositoryBase<Blog>, IBlogRepository
    {
        public BlogRepository(RepositoryContext context) : base(context)
        {
        }

        public IEnumerable<Blog> GetBlogs(Guid id, bool trackChanges)
        {
            return FindByCondition(b => b.UserId.Equals(id), trackChanges)
                .OrderBy(b => b.DateAdded).ToList();
        }
    }
}
