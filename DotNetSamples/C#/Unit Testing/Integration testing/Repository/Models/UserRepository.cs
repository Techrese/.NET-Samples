namespace Repository.Models
{
    public class UserRepository : IDisposable, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public async ValueTask<bool> AddUser(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }
                
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
