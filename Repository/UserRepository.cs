using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateUser(User user)
        {
            Create(user);
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges) 
        {
             return await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            return await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();
        }

        public async Task<User> GetUserAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(u => u.Id.Equals(id), trackChanges)
                .SingleOrDefaultAsync()!;
        }
    }
}
