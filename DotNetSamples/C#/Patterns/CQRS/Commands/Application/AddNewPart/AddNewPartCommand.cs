
namespace Application.AddNewPart
{
    public class AddNewPartCommand : ICommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;
    }
}
