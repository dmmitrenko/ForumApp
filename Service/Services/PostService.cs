using AutoMapper;
using ForumApp.Entities.Exceptions;
using ForumApp.Entities.Models;
using ForumApp.Entities.Responses;
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

    public async Task<ApiBaseResponse> CreatePostAsync(PostForCreationDto post)
    {
        var postEntity = _mapper.Map<Post>(post);

        _repository.Posts.CreatePost(postEntity);
        await _repository.SaveAsync();

        var postToReturn = _mapper.Map<PostDto>(postEntity);

        return new ApiOkResponse<PostDto>(postToReturn);
    }

    public async Task<ApiBaseResponse> CreatePostCollectionAsync(IEnumerable<PostForCreationDto> postCollection)
    {
        if (postCollection is null)
            return new PostCollectionBadRequestResponse();

        var postEntities = _mapper.Map<IEnumerable<Post>>(postCollection);
        foreach (var item in postEntities)
        {
            _repository.Posts.CreatePost(item);
        }
            
        await _repository.SaveAsync();

        var postCollectionToReturn = _mapper.Map<IEnumerable<PostDto>>(postEntities);
        var ids = string.Join(",", postCollectionToReturn.Select(u => u.Id));

        return new ApiOkResponse<(IEnumerable<PostDto> posts, string ids)>((posts: postCollectionToReturn, ids: ids));
    }

    public async Task<ApiBaseResponse> DeletePostAsync(Guid postId)
    {
        var post = await _repository.Posts.GetPostAsync(postId, trackChanges: false);
        
        if (post is null)
            return new PostNotFoundResponse(postId);

        _repository.Posts.DeletePost(post);
        await _repository.SaveAsync();

        return new ApiOkResponse<bool>(true);
    }

    public async Task<ApiBaseResponse> GetAllPostsAsync()
    {
        var posts = await _repository.Posts.GetAllPostsAsync(trackChanges: false);

        var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);

        return new ApiOkResponse<IEnumerable<PostDto>>(postsDto);
    }

    public async Task<ApiBaseResponse> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        if (ids is null)
            return new IdParametersBadRequestResponse();

        var postEntities = await _repository.Posts.GetByIdsAsync(ids, trackChanges: false);
        if (ids.Count() != postEntities.Count())
            return new CollectionByIdsBadRequestResponse();

        var postsToReturn = _mapper.Map<IEnumerable<PostDto>>(postEntities);

        return new ApiOkResponse<IEnumerable<PostDto>>(postsToReturn);
    }

    public async Task<ApiBaseResponse> GetPostAsync(Guid id)
    {
        var post = await _repository.Posts.GetPostAsync(id, trackChanges: false);

        if(post is null)
            return new PostNotFoundResponse(id);

        var postDto = _mapper.Map<PostDto>(post);

        return new ApiOkResponse<PostDto>(postDto);
    }

    public async Task<ApiBaseResponse> UpdatePostAsync(Guid postId, PostForUpdateDto postForUpdate)
    {
        var postEntity = await _repository.Posts.GetPostAsync(postId, trackChanges: false);

        if (postEntity is null)
            return new PostNotFoundResponse(postId);

        var post = _mapper.Map(postForUpdate, postEntity);
        await _repository.SaveAsync();

        var postDto = _mapper.Map<PostDto>(post);
        return new ApiOkResponse<PostDto>(postDto);
    }
}
