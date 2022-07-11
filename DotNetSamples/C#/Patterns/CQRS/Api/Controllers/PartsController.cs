
using Commands.AddNewPart;
using Commands.DeletePart;
using Commands;
using Microsoft.AspNetCore.Mvc;
using Queries;
using Queries.GetPartById;

namespace Api.Controllers
{
    public class PartsController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;


        public PartsController(IHttpContextAccessor httpContextAccessor)
        {            
            _httpContextAccessor = httpContextAccessor;

            _commandDispatcher = new CommandDispatcher(_httpContextAccessor.HttpContext.RequestServices);
            _queryDispatcher = new QueryDispatcher(_httpContextAccessor.HttpContext.RequestServices);

        }

        [HttpGet]
        public IActionResult GetPartById(Guid id)
        {
            var result = _queryDispatcher.Send(new GetPartByIdQuery { Id = id });
            var response = new List<Part>();
            foreach (var item in result)
            {
                response.Add((Part)item);
            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(AddNewPartCommand command)
        {
            _commandDispatcher.Send(command);
            return Ok();
        }

        public IActionResult Delete(DeletePartCommand command)
        {
            _commandDispatcher.Send(command);
            return Ok();
        }
    }
}
