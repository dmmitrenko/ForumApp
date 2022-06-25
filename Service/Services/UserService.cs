using AutoMapper;
using ForumApp.Entities.Exceptions;
using ForumApp.Entities.Models;
using ForumApp.LoggerService;
using ForumApp.Repository.Interfaces;
using ForumApp.Service.Interfaces;
using ForumApp.Shared.DTO;

namespace ForumApp.Service.Services;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public UserService(IRepositoryManager repository, ILoggerManager logger,
        IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<UserDto> CreateUserAsync(UserForCreationDto user)
    {
        var userEntity = _mapper.Map<User>(user);

        _repository.Users.CreateUser(userEntity);
        await _repository.SaveAsync();

        var userToReturn = _mapper.Map<UserDto>(userEntity);

        return userToReturn;
    }

    public async Task<(IEnumerable<UserDto> users, string ids)> CreateUserCollectionAsync
        (IEnumerable<UserForCreationDto> userCollection)
    {
        if (userCollection is null)
            throw new UserCollectionBadRequest();

        var userEntities = _mapper.Map<IEnumerable<User>>(userCollection);
        foreach (var user in userEntities)
        {
            _repository.Users.CreateUser(user);
        }

        await _repository.SaveAsync();

        var userCollectionToReturn = _mapper.Map<IEnumerable<UserDto>>(userEntities);
        var ids = string.Join(",", userCollectionToReturn.Select(u => u.Id));

        return (users: userCollectionToReturn, ids);
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        var user = await GetUserAndCheckIfItExists(userId, trackChanges: false);

        _repository.Users.DeleteUser(user);
        await _repository.SaveAsync();
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await _repository.Users.GetAllUsersAsync(trackChanges: false);

        var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

        return usersDto;
    }

    public async Task<IEnumerable<UserDto>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var userEntities = await _repository.Users.GetByIdsAsync(ids, trackChanges: false);
        if (ids.Count() != userEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var usersToReturn = _mapper.Map<IEnumerable<UserDto>>(userEntities);

        return usersToReturn;
    }

    public async Task<UserDto> GetUserAsync(Guid id)
    {
        var user = await GetUserAndCheckIfItExists(id, trackChanges: false);

        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }

    public async Task UpdateUserAsync(Guid userId, UserForUpdateDto userForUpdate)
    {
        var userEntity = await GetUserAndCheckIfItExists(userId, trackChanges: true);

        _mapper.Map(userForUpdate, userEntity);
        await _repository.SaveAsync();
    }

    private async Task<User> GetUserAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var user = await _repository.Users.GetUserAsync(id, trackChanges);
        if (user is null)
            throw new UserNotFoundException(id);

        return user;
    }
}
