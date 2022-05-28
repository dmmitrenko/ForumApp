using Contracts;
using Service.Contracts;

namespace Service
{
    public class BlogService : IBlogService
    {
        private IRepositoryManager repositoryManager;
        private ILoggerManager logger;

        public BlogService(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            this.repositoryManager = repositoryManager;
            this.logger = logger;
        }
    }
}