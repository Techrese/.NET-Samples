
namespace Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {

        private readonly IServiceProvider _service;

        public QueryDispatcher(IServiceProvider service)
        {
            _service = service;
        }

        public IList<IResult> Send<T>(T query) where T : IQuery
        {
            var handler = _service.GetService(typeof(IQueryHandler<T>));
            if (handler != null)
            {
                return ((IQueryHandler<T>)handler).Handle(query);
            }

            return null;

        }
    }
}
