using Shared.DTO;

namespace Service.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers(bool trackChanges);
        UserDto GetUser(Guid id, bool trackChanges);
        UserDto CreateUser(UserForCreationDto user);
        IEnumerable<UserDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        (IEnumerable<UserDto> users, string ids) CreateUserCollection
            (IEnumerable<UserForCreationDto> userCollection);
    }
}
