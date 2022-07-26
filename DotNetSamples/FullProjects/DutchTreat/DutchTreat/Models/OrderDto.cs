using System.ComponentModel.DataAnnotations;

namespace DutchTreat.Models
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        [MinLength(4)]
        public string OrderNumber { get; set; } = default!;

        public IEnumerable<OrderItem> Items { get; set; }

        public StoreUser User { get; set; }
    }
}
