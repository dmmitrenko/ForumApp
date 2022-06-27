using ForumApp.Entities.Models;
using ForumApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Repository.Repositories;

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
        return await FindByCondition(x => ids.Contains(Guid.Parse(x.Id)), trackChanges).ToListAsync();
    }

    public async Task<User> GetUserAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(u => u.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync()!;
    }
}
