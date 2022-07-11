using Infrastructure;
using Domain;

namespace Commands.AddNewPart
{
    public class AddNewPartCommandHandler : ICommandHandler<AddNewPartCommand>
    {
        private readonly ApplicationContextInMemory _context;

        public AddNewPartCommandHandler(ApplicationContextInMemory context)
        {
            _context = context;
        }

        public async Task Handle(AddNewPartCommand command)
        {
            Part part = new();

            part.Id = command.Id;
            part.Name = command.Name;
            part.Description = command.Description;

            await _context.Parts.AddAsync(part);
        }
    }
}
