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

        public void DeleteBlogForUser(Guid userId, Guid id, bool trackChanges)
        {
            var user = _repository.Users.GetUser(userId, trackChanges);
            if (user is null)
                throw new UserNotFoundException(userId);

            var blogForUser = _repository.Blogs.GetBlog(userId, id, trackChanges);
            if (blogForUser is null)
                throw new BlogNotFoundException(id);

            _repository.Blogs.DeleteBlog(blogForUser);
            _repository.Save();
        }

        public void UpdateBlogForUser(Guid userId, Guid id, BlogForUpdateDto blogForUpdate, 
            bool userTrackChanges, bool blogTrackChanges)
        {
            var user = _repository.Users.GetUser(userId, userTrackChanges);
            if (user is null)
                throw new UserNotFoundException(userId);

            var blogEntity = _repository.Blogs.GetBlog(userId, id, blogTrackChanges);
            if (blogEntity is null)
                throw new BlogNotFoundException(id);

            _mapper.Map(blogForUpdate, blogEntity);
            _repository.Save();
        }

        public (BlogForUpdateDto blogToPatch, Blog blogEntity) GetBlogForPatch(Guid userId, Guid id, bool userTrackChanges, bool blogTrackChanges)
        {
            var user = _repository.Users.GetUser(userId, userTrackChanges);
            if (user is null)
                throw new UserNotFoundException(userId);

            var blogEntity = _repository.Blogs.GetBlog(userId, id, blogTrackChanges);
            if (blogEntity is null)
                throw new BlogNotFoundException(userId);

            var blogToPatch = _mapper.Map<BlogForUpdateDto>(blogEntity);

            return (blogToPatch, blogEntity);
        }

        public void SaveChangesForPatch(BlogForUpdateDto blogToPatch, Blog blogEntity)
        {
            _mapper.Map(blogToPatch, blogEntity);
            _repository.Save();
        }
    }
}