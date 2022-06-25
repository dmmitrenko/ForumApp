using ForumApp.Entities.Models;

namespace ForumApp.Repository.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges);
    Task<User> GetUserAsync(Guid id, bool trackChanges);
    void CreateUser(User user);
    Task<IEnumerable<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteUser(User user);
}
