using AutoMapper;
using ForumApp.Entities.Exceptions;
using ForumApp.Entities.Models;
using ForumApp.LoggerService;
using ForumApp.Repository.Interfaces;
using ForumApp.Service.Interfaces;
using ForumApp.Shared.DTO;
using ForumApp.Shared.RequestFeatures;

namespace ForumApp.Service.Services;

public class CommentService : ICommentService
{
    private IRepositoryManager _repository;
    private ILoggerManager _logger;
    private readonly IMapper _mapper;

    public CommentService(IRepositoryManager repositoryManager, ILoggerManager logger,
        IMapper mapper)
    {
        _repository = repositoryManager;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<CommentDto> comments, MetaData metaData)> GetCommentsAsync(Guid postId, CommentParameters commentParameters)
    {
        await CheckIfPostExists(postId, trackChanges: false);

        var commentsWithMetaData =
            await _repository.Comments.GetCommentsAsync(postId, commentParameters, trackChanges: false);

        var commentsDto = _mapper.Map<IEnumerable<CommentDto>>(commentsWithMetaData);

        return (comments: commentsDto, metaData: commentsWithMetaData.MetaData)!;
    }

    public async Task<CommentDto> GetCommentAsync(Guid postId, Guid id)
    {
        await CheckIfPostExists(postId, trackChanges: false);

        var commentDb = await GetCommentForPostAndCheckIfItExists(postId, id, trackChanges: false);

        var comment = _mapper.Map<CommentDto>(commentDb);
        return comment;
    }

    public async Task<CommentDto> CreateCommentForPostAsync(Guid postId, CommentForCreationDto commentForCreation)
    {
        await CheckIfPostExists(postId, trackChanges: false);

        var commentEntity = _mapper.Map<Comment>(commentForCreation);

        _repository.Comments.CreateCommentForPost(postId, commentEntity);
        await _repository.SaveAsync();

        var blogToReturn = _mapper.Map<CommentDto>(commentEntity);

        return blogToReturn;
    }

    public async Task DeleteCommentForPostAsync(Guid postId, Guid id)
    {
        await CheckIfPostExists(postId, trackChanges: false);

        var commentDb = await GetCommentForPostAndCheckIfItExists(postId, id, trackChanges: false);

        _repository.Comments.DeleteComment(commentDb);
        await _repository.SaveAsync();
    }

    public async Task UpdateCommentForPostAsync(Guid postId, Guid id, CommentForUpdateDto commentForUpdate)
    {
        await CheckIfPostExists(postId, trackChanges: false);

        var commentEntity = await GetCommentForPostAndCheckIfItExists(postId, id, trackChanges: true);

        _mapper.Map(commentForUpdate, commentEntity);
        await _repository.SaveAsync();
    }

    public async Task<(CommentForUpdateDto commentToPatch, Comment commentEntity)> GetCommentForPatchAsync(Guid postId, Guid id)
    {
        await CheckIfPostExists(postId, trackChanges: false);

        var commentDb = await GetCommentForPostAndCheckIfItExists(postId, id, trackChanges: false);

        var commentToPatch = _mapper.Map<CommentForUpdateDto>(commentDb);

        return (commentToPatch, commentEntity: commentDb);
    }

    public async Task SaveChangesForPatchAsync(CommentForUpdateDto commentToPatch, Comment commentEntity)
    {
        _mapper.Map(commentToPatch, commentEntity);
        await _repository.SaveAsync();
    }

    private async Task CheckIfPostExists(Guid postId, bool trackChanges)
    {
        var post = await _repository.Posts.GetPostAsync(postId, trackChanges);
        
        if (post is null)
            throw new PostNotFoundException(postId);
    }

    private async Task<Comment> GetCommentForPostAndCheckIfItExists(Guid postId, Guid id, bool trackChanges)
    {
        var commentDb = await _repository.Comments.GetCommentAsync(postId, id, trackChanges);
        if (commentDb is null)
            throw new CommentNotFoundException(id);

        return commentDb;
    }

}