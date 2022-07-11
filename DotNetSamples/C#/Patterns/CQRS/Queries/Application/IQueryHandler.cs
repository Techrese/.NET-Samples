
namespace Application
{
    public interface IQueryHandler<T> where T: IQuery
    {
        IList<IResult> Handle(T query);
    }
}
