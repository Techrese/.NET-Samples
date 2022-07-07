using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern_Example1
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IDisposable
    {

        protected readonly DbContext _context;        

        public Repository(DbContext context)
        {
            _context = context;
        }

        public async ValueTask AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public async ValueTask<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await (Task<IEnumerable<TEntity>>)_context.Set<TEntity>().Where(predicate);
        }

        public async ValueTask<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async ValueTask<TEntity> GetByIdAsync(object id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
