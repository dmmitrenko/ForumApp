using ForumApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ForumApp.Repository.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected RepositoryContext _context;

    public RepositoryBase(RepositoryContext context)
    {
        _context = context;
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
        if (trackChanges)
            return _context.Set<T>().AsNoTracking();
        return _context.Set<T>();
    }
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        if (trackChanges)
            return _context.Set<T>().Where(expression).AsNoTracking();
        return _context.Set<T>().Where(expression);
    }

    public void Create(T entity) => _context.Set<T>().Add(entity);

    public void Delete(T entity) => _context.Set<T>().Remove(entity);

    public void Update(T entity) => _context.Set<T>().Update(entity);
}
