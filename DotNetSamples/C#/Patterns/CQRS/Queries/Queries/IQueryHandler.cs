
namespace Queries
{
    public interface IQueryHandler<T> where T: IQuery
    {
        IList<IResult> Handle(T query);
    }
}
