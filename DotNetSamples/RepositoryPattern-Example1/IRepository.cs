using System.Linq.Expressions;

namespace RepositoryPattern_Example1
{
    public interface IRepository<TEntity> where TEntity : class
    {        
        ValueTask<TEntity> GetByIdAsync(object id);
        ValueTask<IEnumerable<TEntity>> GetAllAsync();

        ValueTask<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        ValueTask AddAsync(TEntity entity);
        void Remove(TEntity entity);
    }
}