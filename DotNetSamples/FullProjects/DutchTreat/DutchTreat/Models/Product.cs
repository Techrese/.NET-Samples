namespace DutchTreat.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Category { get; set; } = default!;
        public string Size { get; set; } = default!;
        public decimal Price { get; set; }
        public string Title { get; set; } = default!;
        public string ArtDescription { get; set; } = default!;
        public string ArtDating { get; set; } = default!;
        public string ArtId { get; set; } = default!;
        public string ArtList { get; set; } = default!;
        public DateTime ArtistsBirthDate { get; set; }
        public DateTime ArtistDeadthDate { get; set; }
        public string ArtistNationality { get; set; } = default!;

    }
}
