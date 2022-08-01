using AutoMapper;
using ForumApp.Entities.Models;
using ForumApp.LoggerService;
using ForumApp.Repository.Interfaces;
using ForumApp.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ForumApp.Service.Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IPostService> _postService;
    private readonly Lazy<ICommentService> _commentService;
    private readonly Lazy<IAuthenticationService> _authenticationService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger,
        IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
    {
        _postService = new Lazy<IPostService>(() => new PostService(repositoryManager, logger, mapper));
        _commentService = new Lazy<ICommentService>(() => new CommentService(repositoryManager, logger, mapper));
        _authenticationService = new Lazy<IAuthenticationService>(() 
            => new AuthenticationService(logger, mapper, userManager, configuration));
    }

    public IPostService PostService => _postService.Value;

    public ICommentService CommentService => _commentService.Value;

    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}
