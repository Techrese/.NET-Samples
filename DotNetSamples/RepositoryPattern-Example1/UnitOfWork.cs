using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern_Example1
{
    public class UnitOfWork: IDisposable
    {
       // public IRepository<> HeaderRepository { get; private set; } replace with your repository
        private readonly DbContext _context // private applicationcontext context
        private bool disposed = false;

        public UnitOfWork(DbContext context) //replace dbcontext with your context aka applicationcontext
        {
            _context = context;
            //set new repository with property
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }



    
}
