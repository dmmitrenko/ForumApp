using ForumApp.Entities.Models;
using ForumApp.Repository.Interfaces;
using ForumApp.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Repository.Repositories;

internal class CommentRepository : RepositoryBase<Comment>, ICommentRepository
{
    public CommentRepository(RepositoryContext context) : base(context)
    {
    }

    public void CreateCommentForPost(Guid postId, Comment comment)
    {
        comment.PostId = postId;
        Create(comment);
    }

    public void DeleteComment(Comment comment)
    {
        Delete(comment);
    }

    public async Task<Comment> GetCommentAsync(Guid postId, Guid id, bool trackChanges)
    {
        return await
            FindByCondition(comment => 
            comment.PostId.Equals(postId) && comment.Id.Equals(id),trackChanges)
            .FirstAsync();
    }

    public async Task<PagedList<Comment>> GetCommentsAsync(Guid id, CommentParameters commentParameters, bool trackChanges)
    {
        var comments = 
            await FindByCondition(c => c.PostId.Equals(id) && 
                (c.DateAdded >= commentParameters.MinDate && c.DateAdded <= commentParameters.MaxDate), trackChanges)
            .OrderBy(c => c.DateAdded.ToString())
            .Skip((commentParameters.PageNumber - 1) * commentParameters.PageSize)
            .Take(commentParameters.PageSize)
            .ToListAsync();

        var count = await FindByCondition(c => c.PostId.Equals(id), trackChanges)
            .CountAsync();

        return new PagedList<Comment>(comments, count,
            commentParameters.PageNumber, commentParameters.PageSize);
    }
}
