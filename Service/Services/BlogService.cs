using AutoMapper;
using ForumApp.Entities.Exceptions;
using ForumApp.Entities.Models;
using ForumApp.LoggerService;
using ForumApp.Repository.Interfaces;
using ForumApp.Service.Interfaces;
using ForumApp.Shared.DTO;
using ForumApp.Shared.RequestFeatures;

namespace ForumApp.Service.Services;

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

    public async Task<(IEnumerable<BlogDto> blogs, MetaData metaData)> GetBlogsAsync(
        Guid userId, BlogParameters blogParameters)
    {
        await CheckIfUserExists(userId, trackChanges: false);

        var blogsWithMetaData =
            await _repository.Blogs.GetBlogsAsync(userId, blogParameters, trackChanges: false);

        var blogsDto = _mapper.Map<IEnumerable<BlogDto>>(blogsWithMetaData);

        return (blogs: blogsDto, metaData: blogsWithMetaData.MetaData)!;
    }

    public async Task<BlogDto> GetBlogAsync(Guid userId, Guid id)
    {
        await CheckIfUserExists(userId, trackChanges: false);

        var blogDb = await GetBlogForUserAndCheckIfItExists(userId, id, trackChanges: false);

        var blog = _mapper.Map<BlogDto>(blogDb);
        return blog;
    }

    public async Task<BlogDto> CreateBlogForUserAsync(Guid userId, BlogForCreationDto blogForCreation)
    {
        await CheckIfUserExists(userId, trackChanges: false);

        var blogEntity = _mapper.Map<Blog>(blogForCreation);

        _repository.Blogs.CreateBlogForUser(userId, blogEntity);
        await _repository.SaveAsync();

        var blogToReturn = _mapper.Map<BlogDto>(blogEntity);

        return blogToReturn;
    }

    public async Task DeleteBlogForUserAsync(Guid userId, Guid id)
    {
        await CheckIfUserExists(userId, trackChanges: false);

        var blogDb = await GetBlogForUserAndCheckIfItExists(userId, id, trackChanges: false);

        _repository.Blogs.DeleteBlog(blogDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateBlogForUserAsync(Guid userId, Guid id, BlogForUpdateDto blogForUpdate)
    {
        await CheckIfUserExists(userId, trackChanges: false);

        var blogEntity = await GetBlogForUserAndCheckIfItExists(userId, id, trackChanges: true);

        _mapper.Map(blogForUpdate, blogEntity);
        await _repository.SaveAsync();
    }

    public async Task<(BlogForUpdateDto blogToPatch, Blog blogEntity)> GetBlogForPatchAsync
        (Guid userId, Guid id)
    {
        await CheckIfUserExists(userId, trackChanges: false);

        var blogDb = await GetBlogForUserAndCheckIfItExists(userId, id, trackChanges: false);

        var blogToPatch = _mapper.Map<BlogForUpdateDto>(blogDb);

        return (blogToPatch, blogEntity: blogDb);
    }

    public async Task SaveChangesForPatchAsync(BlogForUpdateDto blogToPatch, Blog blogEntity)
    {
        _mapper.Map(blogToPatch, blogEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfUserExists(Guid userId, bool trackChanges)
    {
        var user = await _repository.Posts.GetUserAsync(userId, trackChanges);
        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }
    }

    private async Task<Blog> GetBlogForUserAndCheckIfItExists
        (Guid userId, Guid id, bool trackChanges)
    {
        var blogDb = await _repository.Blogs.GetBlogAsync(userId, id, trackChanges);
        if (blogDb is null)
            throw new BlogNotFoundException(id);

        return blogDb;

    }
}