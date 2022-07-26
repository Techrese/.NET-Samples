using AutoMapper;
using DutchTreat.Models;
using DutchTreat.Models.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrdersController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<StoreUser> _userManager

        public OrdersController(IProductRepository repostiory,  IMapper mapper, UserManager<StoreUser> userManager)
        {
            _repository = repostiory;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Get(bool includeItems = true)
        {
            try
            {
                var username = User.Identity.Name;
                var result = _repository.GetAllOrdersByUser(username, includeItems);
                return Ok(_mapper.Map<IEnumerable<OrderDto>>(result));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var order = _repository.GetOrderById(User.Identity.Name,id);
                if (order != null)
                {
                    return Ok(_mapper.Map<Order, OrderDto>(order));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(OrderDto order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (order.OrderDate == DateTime.MinValue)
                {
                    order.OrderDate = DateTime.Now;
                }

                var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);

                order.User = currentUser;

                _repository.AddEntity(_mapper.Map<Order>(order));
                _repository.Save();

                return Created($"api/orders/{order.OrderId}", order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
