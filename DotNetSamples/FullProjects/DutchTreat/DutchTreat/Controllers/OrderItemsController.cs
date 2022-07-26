using AutoMapper;
using DutchTreat.Models;
using DutchTreat.Models.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
    [Route("api/orders/{orderid}/items")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderItemsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public OrderItemsController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(Guid orderId)
        {
            try
            {
                var order = _repository.GetOrderByIdByUser(User.Identity.Name,orderId);
                if (order != null)
                {
                    return Ok(_mapper.Map<IEnumerable<OrderItemDto>>(order));
                }

                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid orderId, Guid id)
        {
            try
            {
                var order = _repository.GetOrderById(User.Identity.Name,orderId);
                if (order != null)
                {
                    var item = order.Items.FirstOrDefault(x => x.Id == id);
                    if (item != null)
                    {
                        return Ok(_mapper.Map<OrderItemDto>(order));
                    }
                    
                }

                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
