using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IBlogRepository> _blogRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _userRepository =
                new Lazy<IUserRepository>(() => new UserRepository(context));
            _blogRepository =
                new Lazy<IBlogRepository>(() => new BlogRepository(context));
        }

        public IUserRepository Users => _userRepository.Value;

        public IBlogRepository Blogs => _blogRepository.Value;

        public void Save() => _context.SaveChanges();
    }
}
