
using Infrastructure;

namespace Commands.DeletePart
{
    public class DeletePartCommandHandler : ICommandHandler<DeletePartCommand>
    {

        private readonly ApplicationContextInMemory _context;

        public DeletePartCommandHandler(ApplicationContextInMemory context)
        {
            _context = context;
        }

        public Task Handle(DeletePartCommand command)
        {
            var part = _context.Parts.SingleOrDefault(x => x.Id == command.Id);
            if (part != null)
            {
                _context.Parts.Remove(part);
            }

            return Task.CompletedTask;
        }
    }
}
