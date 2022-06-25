using ForumApp.Repository.Interfaces;
using ForumApp.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Repository.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    private readonly Lazy<IUserRepository> _userRepository;
    private readonly Lazy<IBlogRepository> _blogRepository;
    private readonly Lazy<ICommentRepository> _commentRepository;

    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
        _userRepository =
            new Lazy<IUserRepository>(() => new UserRepository(context));
        _blogRepository =
            new Lazy<IBlogRepository>(() => new BlogRepository(context));
        _commentRepository =
            new Lazy<ICommentRepository>(() => new CommentRepository(context));
    }

    public IUserRepository Users => _userRepository.Value;

    public IBlogRepository Blogs => _blogRepository.Value;

    public ICommentRepository Comments => _commentRepository.Value;

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}
