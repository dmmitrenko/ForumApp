using ForumApp.Entities.Models;

namespace ForumApp.Repository.Interfaces;

public interface IPostRepository
{
    Task<IEnumerable<Blog>> GetAllPostsAsync(bool trackChanges);
    Task<Blog> GetPostAsync(Guid id, bool trackChanges);
    void CreatePost(Blog blog);
    Task<IEnumerable<Blog>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    void DeletePost(Blog blog);
}
