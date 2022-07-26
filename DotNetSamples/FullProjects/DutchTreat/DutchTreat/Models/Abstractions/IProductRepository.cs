namespace DutchTreat.Models.Abstractions
{
    public interface IProductRepository
    {

        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);        
        Order GetOrderById(string username, Guid id);
        void AddEntity(object order);
        void Save();
        IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems);        
    }
}
