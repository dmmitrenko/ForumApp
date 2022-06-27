using ForumApp.Entities.Models;
using ForumApp.Shared.RequestFeatures;

namespace ForumApp.Repository.Interfaces;

public interface ICommentRepository
{
    Task<PagedList<Comment>> GetCommentsAsync(Guid id, CommentParameters commentParameters, bool trackChanges);
    Task<Comment> GetCommentAsync(Guid postId, Guid id, bool trackChanges);
    void CreateCommentForPost(Guid postId, Comment comment);
    void DeleteComment(Comment comment);
}
