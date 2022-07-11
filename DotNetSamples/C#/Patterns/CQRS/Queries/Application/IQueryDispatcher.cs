namespace Application
{
    public interface IQueryDispatcher<T> where T : IQuery
    {
        IList<IResult> Send(T query);
    }
}
