using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
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
            var user = _repository.Users.GetUser(userId, trackChanges);
            
            if (user is null)
                throw new UserNotFoundException(userId);

            var blogsFromDb = _repository.Blogs.GetBlogs(userId, trackChanges);
            var blogsDto = _mapper.Map<IEnumerable<BlogDto>>(blogsFromDb);

            return blogsDto;
        }

        public BlogDto GetBlog(Guid userId, Guid id, bool trackChanges)
        {
            var user = _repository.Users.GetUser(userId, trackChanges);
            if (user is null)
                throw new UserNotFoundException(userId);

            var blogDb = _repository.Blogs.GetBlog(userId,id,trackChanges);
            if (blogDb is null)
                throw new BlogNotFoundException(id);

            var blog = _mapper.Map<BlogDto>(blogDb);
            return blog;
        }

        public BlogDto CreateBlogForUser(Guid userId, BlogForCreationDto blogForCreation, bool trackChanges)
        {
            var user = _repository.Users.GetUser(userId, trackChanges);

            if (user is null)
                throw new UserNotFoundException(userId);

            var blogEntity = _mapper.Map<Blog>(blogForCreation);

            _repository.Blogs.CreateBlogForUser(userId, blogEntity);
            _repository.Save();

            var blogToReturn = _mapper.Map<BlogDto>(blogEntity);

            return blogToReturn;
        }
    }
}