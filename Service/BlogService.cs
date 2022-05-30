using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DTO;

namespace Service
{
    public class BlogService : IBlogService
    {
        private IRepositoryManager _repository;
        private ILoggerManager _logger;
        private readonly IMapper _mapper;

        public BlogService(IRepositoryManager repositoryManager, ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<BlogDto> GetBlogs(Guid userId, bool trackChanges)
        {
            var user = _repository.Users.GetUserById(userId, trackChanges);
            
            if (user is null)
                throw new UserNotFoundException(userId);

            var blogsFromDb = _repository.Blogs.GetBlogs(userId, trackChanges);
            var blogsDto = _mapper.Map<IEnumerable<BlogDto>>(blogsFromDb);

            return blogsDto;
        }
    }
}