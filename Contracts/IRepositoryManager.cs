namespace Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository Users { get; }
        IBlogRepository Blogs { get; }
        ICommentRepository Comments { get; }
        Task SaveAsync();
    }
}
