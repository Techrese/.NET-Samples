namespace DutchTreat.Models.Abstractions
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

    }
}
