using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using System.Threading.Tasks;

namespace Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;

        public UsersController(ApplicationDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            return Ok(_userRepository.GetAll());
        }

        [HttpPost]
        public async ValueTask<ActionResult> NewUser(User user)
        {
            if (await _userRepository.AddUser(user))
            {
                return Ok();
            }
            else 
            {
                return BadRequest();
            }          
        }

        public ActionResult UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
            return Ok();
        }
        
    }
}
