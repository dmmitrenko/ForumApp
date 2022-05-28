using Contracts;
using Service.Contracts;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IBlogService> _blogService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger));
            _blogService = new Lazy<IBlogService>(() => new BlogService(repositoryManager, logger));
        }

        public IUserService UserService => throw new NotImplementedException();

        public IBlogService BLogService => throw new NotImplementedException();
    }
}
