namespace Queries
{
    public interface IQueryDispatcher
    {
        IList<IResult> Send<T>(T query) where T: IQuery;
    }
}
