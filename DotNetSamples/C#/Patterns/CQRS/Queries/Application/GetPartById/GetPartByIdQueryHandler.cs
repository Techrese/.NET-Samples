using Infrastructure;

namespace Application.GetPartById
{
    public class GetPartByIdQueryHandler : IQueryHandler<GetPartByIdQuery>
    {
        private readonly ApplicationContextInMemory _context;

        public GetPartByIdQueryHandler(ApplicationContextInMemory context)
        {
            _context = context;
        }

        public IList<IResult> Handle(GetPartByIdQuery query)
        {
            var partQuery = _context.Parts.SingleOrDefault(x => x.Id == query.Id);
            var results = new List<IResult>();
            if (partQuery != null)
            {
                
                Part part = new()
                {
                    Id = partQuery.Id,
                    Name = partQuery.Name,
                    Description = partQuery.Description, 
                };
                results.Add(part);
            }

            return results;
        }
    }
}
