
namespace Application
{
    public class Part : IResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;
    }
}
