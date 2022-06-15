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

        public async Task<IEnumerable<BlogDto>> GetBlogsAsync(Guid userId, bool trackChanges)
        {
            var user = await _repository.Users.GetUserAsync(userId, trackChanges);
            
            if (user is null)
                throw new UserNotFoundException(userId);

            var blogsFromDb = await _repository.Blogs.GetBlogsAsync(userId, trackChanges);
            var blogsDto = _mapper.Map<IEnumerable<BlogDto>>(blogsFromDb);

            return blogsDto;
        }

        public async Task<BlogDto> GetBlogAsync(Guid userId, Guid id, bool trackChanges)
        {
            var user = await _repository.Users.GetUserAsync(userId, trackChanges);
            if (user is null)
                throw new UserNotFoundException(userId);

            var blogDb = await _repository.Blogs.GetBlogAsync(userId,id,trackChanges);
            if (blogDb is null)
                throw new BlogNotFoundException(id);

            var blog = _mapper.Map<BlogDto>(blogDb);
            return blog;
        }

        public async Task<BlogDto> CreateBlogForUserAsync(Guid userId, BlogForCreationDto blogForCreation, bool trackChanges)
        {
            var user = await _repository.Users.GetUserAsync(userId, trackChanges);

            if (user is null)
                throw new UserNotFoundException(userId);

            var blogEntity = _mapper.Map<Blog>(blogForCreation);

            _repository.Blogs.CreateBlogForUser(userId, blogEntity);
            await _repository.SaveAsync();

            var blogToReturn = _mapper.Map<BlogDto>(blogEntity);

            return blogToReturn;
        }

        public async Task DeleteBlogForUserAsync(Guid userId, Guid id, bool trackChanges)
        {
            var user = await _repository.Users.GetUserAsync(userId, trackChanges);
            if (user is null)
                throw new UserNotFoundException(userId);

            var blogForUser = await _repository.Blogs.GetBlogAsync(userId, id, trackChanges);
            if (blogForUser is null)
                throw new BlogNotFoundException(id);

            _repository.Blogs.DeleteBlog(blogForUser);
            await _repository.SaveAsync();
        }

        public async Task UpdateBlogForUserAsync(Guid userId, Guid id, BlogForUpdateDto blogForUpdate, 
            bool userTrackChanges, bool blogTrackChanges)
        {
            var user = await _repository.Users.GetUserAsync(userId, userTrackChanges);
            if (user is null)
                throw new UserNotFoundException(userId);

            var blogEntity = await _repository.Blogs.GetBlogAsync(userId, id, blogTrackChanges);
            if (blogEntity is null)
                throw new BlogNotFoundException(id);

            _mapper.Map(blogForUpdate, blogEntity);
            await _repository.SaveAsync();
        }

        public async Task<(BlogForUpdateDto blogToPatch, Blog blogEntity)> GetBlogForPatchAsync(Guid userId, Guid id, bool userTrackChanges, bool blogTrackChanges)
        {
            var user = await _repository.Users.GetUserAsync(userId, userTrackChanges);
            if (user is null)
                throw new UserNotFoundException(userId);

            var blogEntity = await _repository.Blogs.GetBlogAsync(userId, id, blogTrackChanges);
            if (blogEntity is null)
                throw new BlogNotFoundException(userId);

            var blogToPatch = _mapper.Map<BlogForUpdateDto>(blogEntity);

            return (blogToPatch, blogEntity);
        }

        public async Task SaveChangesForPatchAsync(BlogForUpdateDto blogToPatch, Blog blogEntity)
        {
            _mapper.Map(blogToPatch, blogEntity);
            await _repository.SaveAsync();
        }
    }
}