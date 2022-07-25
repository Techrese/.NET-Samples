namespace DutchTreat.Models
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public Guid Product { get; set; }
        public string ProductCategory { get; set; } = default!;
        public string ProductSize { get; set; } = default!;    
        public string ProductTitle { get; set; } = default!;        
        public string ProductArtId { get; set; } = default!;        
        public string ProductArtiist { get; set; } = default!;
        


    }
}
