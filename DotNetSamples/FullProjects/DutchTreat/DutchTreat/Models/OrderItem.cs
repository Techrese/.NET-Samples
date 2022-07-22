namespace DutchTreat.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Order Order { get; set; } = default!;
    }
}
