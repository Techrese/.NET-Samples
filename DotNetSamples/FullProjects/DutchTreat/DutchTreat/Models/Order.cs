namespace DutchTreat.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; } = default!;
        public virtual ICollection<OrderItem> Items { get; set; }

    }
}
