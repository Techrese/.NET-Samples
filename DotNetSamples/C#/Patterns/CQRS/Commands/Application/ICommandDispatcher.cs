
namespace Application
{
    public interface ICommandDispatcher<T> where T : ICommand
    {
        void Send(T command);
    }
}
