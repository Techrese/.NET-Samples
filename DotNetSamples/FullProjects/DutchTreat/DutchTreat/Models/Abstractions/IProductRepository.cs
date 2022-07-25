namespace DutchTreat.Models.Abstractions
{
    public interface IProductRepository
    {

        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(Guid id);
        void AddEntity(object order);
        void Save();
    }
}
