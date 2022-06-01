using Entities.Models;

namespace Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers(bool trackChanges); 
        User GetUserById(Guid id, bool trackChanges);
        void CreateUser(User user);
    }
}
