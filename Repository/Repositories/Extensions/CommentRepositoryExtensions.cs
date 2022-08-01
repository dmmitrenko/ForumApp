using ForumApp.Entities.Models;

namespace ForumApp.Repository.Repositories.Extensions;

public static class CommentRepositoryExtensions
{
    public static IQueryable<Comment> FilterComments(this IQueryable<Comment> comments, 
        DateTime minDate, DateTime maxDate)
    {
        return comments.Where(comment => (comment.DateAdded >= minDate && comment.DateAdded <= maxDate));
    }

    public static IQueryable<Comment> Search(this IQueryable<Comment> comments, string searchTerm)
    {
        if(string.IsNullOrEmpty(searchTerm))
            return comments;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        return comments.Where(item => item.UserId.ToString() == lowerCaseTerm);
    }
}
