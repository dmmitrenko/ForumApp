using ForumApp.Entities.Models;
using ForumApp.Repository.Interfaces;

namespace ForumApp.Repository.Repositories;

internal class CommentRepository : RepositoryBase<Comment>, ICommentRepository
{
    public CommentRepository(RepositoryContext context) : base(context)
    {
    }
}
