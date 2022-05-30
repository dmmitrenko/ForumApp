using Shared.DTO;

namespace Service.Contracts
{
    public interface IBlogService
    {
        IEnumerable<BlogDto> GetBlogs(Guid userId, bool trackChanges);
    }
}
