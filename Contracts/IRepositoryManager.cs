namespace Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository Users { get; }
        IBlogRepository Blogs { get; }
        void Save();
    }
}
