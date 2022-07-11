
namespace Domain
{
    public class Part
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public Guid PartLineId { get; set; }

        public virtual PartLines PartLines { get; set; } = default!;
    }
}
