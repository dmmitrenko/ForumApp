using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
    public class BlogService : IBlogService
    {
        private IRepositoryManager _repositoryManager;
        private ILoggerManager _logger;
        private readonly IMapper _mapper;

        public BlogService(IRepositoryManager repositoryManager, ILoggerManager logger,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }
    }
}