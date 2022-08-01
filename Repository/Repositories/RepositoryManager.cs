using ForumApp.Repository.Interfaces;

namespace ForumApp.Repository.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    private readonly Lazy<IPostRepository> _postRepository;
    private readonly Lazy<ICommentRepository> _commentRepository;

    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
        _postRepository =
            new Lazy<IPostRepository>(() => new PostRepository(context));
        _commentRepository =
            new Lazy<ICommentRepository>(() => new CommentRepository(context));
    }

    public IPostRepository Posts => _postRepository.Value;

    public ICommentRepository Comments => _commentRepository.Value;

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}
