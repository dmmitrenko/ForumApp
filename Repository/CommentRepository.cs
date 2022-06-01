using Contracts;
using Entities.Models;

namespace Repository
{
    internal class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
