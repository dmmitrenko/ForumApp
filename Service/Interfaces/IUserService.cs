using ForumApp.Shared.DTO;

namespace ForumApp.Service.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserAsync(Guid id);
    Task<UserDto> CreateUserAsync(UserForCreationDto user);
    Task<IEnumerable<UserDto>> GetByIdsAsync(IEnumerable<Guid> ids);
    Task<(IEnumerable<UserDto> users, string ids)> CreateUserCollectionAsync
        (IEnumerable<UserForCreationDto> userCollection);
    Task DeleteUserAsync(Guid userId);
    Task UpdateUserAsync(Guid userId, UserForUpdateDto userForUpdate);
}
