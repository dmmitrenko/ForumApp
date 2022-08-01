using ForumApp.Entities.Models;
using ForumApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Repository.Repositories;

public class PostRepository : RepositoryBase<Post>, IPostRepository
{
    public PostRepository(RepositoryContext context) : base(context)
    {
    }

    public void CreatePost(Post post)
    {
        Create(post);
    }

    public void DeletePost(Post post)
    {
        Delete(post);
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).OrderBy(c => c.UserId).ToListAsync();
    }

    public async Task<IEnumerable<Post>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        return await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();
    }

    public async Task<Post> GetPostAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(post => post.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }
}
