using ForumApp.Shared.DTO;

namespace ForumApp.Service.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync(bool trackChanges);
    Task<UserDto> GetUserAsync(Guid id, bool trackChanges);
    Task<UserDto> CreateUserAsync(UserForCreationDto user);
    Task<IEnumerable<UserDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    Task<(IEnumerable<UserDto> users, string ids)> CreateUserCollectionAsync
        (IEnumerable<UserForCreationDto> userCollection);
    Task DeleteUserAsync(Guid userId, bool trackChanges);
    Task UpdateUserAsync(Guid userId, UserForUpdateDto userForUpdate, bool trackChanges);
}
