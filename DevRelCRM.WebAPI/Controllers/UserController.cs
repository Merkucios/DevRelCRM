using DevRelCRM.Core.DomainModels;
using DevRelCRM.Application.Users.Queries;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using DevRelCRM.Application.Users.Commands;
using DevRelCRM.WebAPI.DataTransferObjects;
using AutoMapper;

namespace DevRelCRM.WebAPI.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UserController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        private static List<User> users = new List<User>
        {
            new User
            {
                UserId = Guid.NewGuid(), 
                Name = "Test", 
                Surname = "TestSurname",
                Patronym = null,
                NickName = "TestNickname",
                Email = "test@devrelcrm.com",
                Password = "passwrod",
                Role = null,
                DateCreated = DateTime.Now,

            }

        };

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDetailsVm>> GetUserDetails(Guid userId)
        {
            var query = new GetUserDetailsQuery { UserId = userId };
            var userDetails = await _mediator.Send(query);

            if (userDetails == null)
            {
                return NotFound();
            }
            return Ok(userDetails);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            var command = _mapper.Map<CreateUserCommand>(createUserDTO);
            var userId = await _mediator.Send(command);
            return Ok(userId);
            
        }
    }
}
