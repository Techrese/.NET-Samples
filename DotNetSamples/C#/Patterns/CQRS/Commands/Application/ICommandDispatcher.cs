
namespace Application
{
    public interface ICommandDispatcher<T> where T : class
    {
        void Send<T>(T command);
    }
}
