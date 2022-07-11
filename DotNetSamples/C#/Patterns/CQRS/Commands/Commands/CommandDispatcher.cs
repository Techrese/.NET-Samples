namespace Commands
{  

    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _service;

        public CommandDispatcher(IServiceProvider service)
        {
            _service = service;
        }

        public void Send<T>(T command) where T : ICommand
        {
            var handler = _service.GetService(typeof(ICommandHandler<T>));
            if (handler != null)
            {
                ((ICommandHandler<T>)handler).Handle(command);
            }                
        }

    }
}
