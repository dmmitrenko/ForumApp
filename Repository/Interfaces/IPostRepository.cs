using ForumApp.Entities.Models;

namespace ForumApp.Repository.Interfaces;

public interface IPostRepository
{
    Task<IEnumerable<Post>> GetAllPostsAsync(bool trackChanges);
    Task<Post> GetPostAsync(Guid id, bool trackChanges);
    void CreatePost(Post post);
    Task<IEnumerable<Post>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    void DeletePost(Post post);
}
