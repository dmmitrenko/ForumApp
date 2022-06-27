using ForumApp.Entities.Models;
using ForumApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Repository.Repositories;

public class PostRepository : RepositoryBase<Blog>, IPostRepository
{
    public PostRepository(RepositoryContext context) : base(context)
    {
    }

    public void CreatePost(Blog blog)
    {
        Create(blog);
    }

    public void DeletePost(Blog blog)
    {
        Delete(blog);
    }

    public async Task<IEnumerable<Blog>> GetAllPostsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).OrderBy(c => c.UserId).ToListAsync();
    }

    public async Task<IEnumerable<Blog>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        return await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();
    }

    public async Task<Blog> GetPostAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(post => post.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }
}
