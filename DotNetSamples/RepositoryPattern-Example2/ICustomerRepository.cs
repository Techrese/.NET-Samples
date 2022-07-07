namespace RepositoryPattern_Example2
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(Guid id);
        ValueTask InsertCustoemrAsync(Customer customer);
        void DeleteCustomer(Guid id);
        void UpdateCustomerAsync(Customer customer);        
    }
}
