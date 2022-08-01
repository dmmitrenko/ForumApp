namespace ForumApp.Service.Interfaces;

public interface IServiceManager
{
    IPostService PostService { get; }
    ICommentService CommentService { get; }
    IAuthenticationService AuthenticationService { get; }
}
