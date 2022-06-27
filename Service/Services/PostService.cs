using AutoMapper;
using ForumApp.Entities.Exceptions;
using ForumApp.Entities.Models;
using ForumApp.LoggerService;
using ForumApp.Repository.Interfaces;
using ForumApp.Service.Interfaces;
using ForumApp.Shared.DTO;

namespace ForumApp.Service.Services;

public class PostService : IPostService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public PostService(IRepositoryManager repository, ILoggerManager logger,
        IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<PostDto> CreatePostAsync(PostForCreationDto post)
    {
        var postEntity = _mapper.Map<Blog>(post);

        _repository.Posts.CreatePost(postEntity);
        await _repository.SaveAsync();

        var postToReturn = _mapper.Map<PostDto>(postEntity);

        return postToReturn;
    }

    public async Task<(IEnumerable<PostDto> posts, string ids)> CreatePostCollectionAsync(IEnumerable<PostForCreationDto> postCollection)
    {
        if (postCollection is null)
            throw new PostCollectionBadRequest();

        var postEntities = _mapper.Map<IEnumerable<Blog>>(postCollection);
        foreach (var item in postEntities)
        {
            _repository.Posts.CreatePost(item);
        }
            
        await _repository.SaveAsync();

        var postCollectionToReturn = _mapper.Map<IEnumerable<PostDto>>(postEntities);
        var ids = string.Join(",", postCollectionToReturn.Select(u => u.Id));

        return (posts: postCollectionToReturn, ids: ids);
    }

    public async Task DeletePostAsync(Guid postId)
    {
        var post = await GetPostAndCheckIfItExists(postId, trackChanges: false);

        _repository.Posts.DeletePost(post);
        await _repository.SaveAsync();
    }

    public async Task<IEnumerable<PostDto>> GetAllPostsAsync()
    {
        var posts = await _repository.Posts.GetAllPostsAsync(trackChanges: false);

        var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);

        return postsDto;
    }

    public async Task<IEnumerable<PostDto>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var postEntities = await _repository.Posts.GetByIdsAsync(ids, trackChanges: false);
        if (ids.Count() != postEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var postsToReturn = _mapper.Map<IEnumerable<PostDto>>(postEntities);

        return postsToReturn;
    }

    public async Task<PostDto> GetPostAsync(Guid id)
    {
        var post = await GetPostAndCheckIfItExists(id, trackChanges: false);

        var postDto = _mapper.Map<PostDto>(post);
        return postDto;
    }

    public async Task UpdatePostAsync(Guid postId, PostForUpdateDto postForUpdate)
    {
        var postEntity = await GetPostAndCheckIfItExists(postId, trackChanges: false);

        _mapper.Map(postForUpdate, postEntity);
        await _repository.SaveAsync();
    }

    private async Task<Blog> GetPostAndCheckIfItExists(Guid postId, bool trackChanges)
    {
        var post = await _repository.Posts.GetPostAsync(postId, trackChanges);
        if (post is null)
            throw new PostNotFoundException(postId);

        return post;
    }
}
