using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IBlogService> _blogService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger,
            IMapper mapper)
        {
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger, mapper));
            _blogService = new Lazy<IBlogService>(() => new BlogService(repositoryManager, logger, mapper));
        }

        public IUserService UserService => _userService.Value;

        public IBlogService BLogService => _blogService.Value;
    }
}
