namespace Application
{
    public interface ICommandHandler<T> where T : class
    {
        Task Handle(T command);
    }
}
