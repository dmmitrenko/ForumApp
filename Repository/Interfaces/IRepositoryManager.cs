namespace ForumApp.Repository.Interfaces;

public interface IRepositoryManager
{
    IPostRepository Posts { get; }
    ICommentRepository Comments { get; }
    Task SaveAsync();
}
