namespace Repository.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        ValueTask<bool> AddUser(User user);
        void UpdateUser(User user);
    }
}
