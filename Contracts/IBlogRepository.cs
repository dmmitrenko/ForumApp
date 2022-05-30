using Entities.Models;

namespace Contracts
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetBlogs(Guid id, bool trackChanges);
    }
}
