using Shared.DTO;

namespace Service.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers(bool trackChanges);
        UserDto GetUser(Guid id, bool trackChanges);
    }
}
