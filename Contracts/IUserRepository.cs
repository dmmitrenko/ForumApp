using Entities.Models;

namespace Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers(bool trackChanges); 
        User GetUser(Guid id, bool trackChanges);
        void CreateUser(User user);
        IEnumerable<User> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    }
}
