using ForumApp.Entities.Models;
using ForumApp.Shared.DTO;
using ForumApp.Shared.RequestFeatures;

namespace ForumApp.Service.Interfaces
{
    public interface ICommentService
    {
        Task<(IEnumerable<CommentDto> comments, MetaData metaData)> GetCommentsAsync(Guid postId, CommentParameters commentParameters);
        Task<CommentDto> GetCommentAsync(Guid postId, Guid id);
        Task<CommentDto> CreateCommentForUserAsync(Guid postId, CommentForCreationDto commentForCreation);
        Task DeleteCommentForPostAsync(Guid postId, Guid id);
        Task UpdateCommentForPostAsync(Guid postId, Guid id, CommentForUpdateDto commentForUpdate);
        Task<(CommentForUpdateDto blogToPatch, Comment commentEntity)> GetCommentForPatchAsync(
            Guid postId, Guid id);
        Task SaveChangesForPatchAsync(CommentForUpdateDto commentToPatch, Comment commentEntity);
    }
}
