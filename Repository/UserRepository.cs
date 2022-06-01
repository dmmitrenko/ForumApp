using Contracts;
using Entities.Models;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateUser(User user) => Create(user);
        
        public IEnumerable<User> GetAllUsers(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(c => c.Name).ToList();
        }

        public User GetUserById(Guid id, bool trackChanges)
        {
            return FindByCondition(u => u.Id.Equals(id), trackChanges)
                .SingleOrDefault()!;
        }
    }
}
