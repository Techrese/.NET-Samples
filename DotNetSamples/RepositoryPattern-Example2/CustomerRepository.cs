using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern_Example2
{
    public class CustomerRepository : ICustomerRepository
    {

        private ApplicationContext _context;
        

        public CustomerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void DeleteCustomer(Guid id)
        {
            var customer = _context.Find<Customer>(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
           
        }

        public Customer GetCustomerById(Guid id)
        {
            return _context.Customers.Find(id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public async ValueTask InsertCustoemrAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }       

        public void UpdateCustomerAsync(Customer customer)
        {
            return _context.Customers.Update(customer);
        }
    }
}
