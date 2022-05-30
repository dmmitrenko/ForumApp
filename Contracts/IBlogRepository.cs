﻿using Entities.Models;

namespace Contracts
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetBlogs(Guid id, bool trackChanges);
        Blog GetBlog(Guid userId, Guid id, bool trackChanges);
    }
}
