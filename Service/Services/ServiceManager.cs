using AutoMapper;
using ForumApp.Entities.Models;
using ForumApp.LoggerService;
using ForumApp.Repository.Interfaces;
using ForumApp.Service.Interfaces;
using ForumApp.Service.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ForumApp.Service.Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IUserService> _userService;
    private readonly Lazy<IBlogService> _blogService;
    private readonly Lazy<IAuthenticationService> _authenticationService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger,
        IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
    {
        _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger, mapper));
        _blogService = new Lazy<IBlogService>(() => new BlogService(repositoryManager, logger, mapper));
        _authenticationService = new Lazy<IAuthenticationService>(() 
            => new AuthenticationService(logger, mapper, userManager, configuration));
    }

    public IUserService UserService => _userService.Value;

    public IBlogService BLogService => _blogService.Value;

    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}
