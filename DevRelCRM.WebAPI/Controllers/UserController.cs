using AutoMapper;
using DevRelCRM.Core.DomainModels;
using DevRelCRM.WebAPI.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevRelCRM.WebAPI.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static List<User> users = new List<User>
        {
            new User
            {
                Id = Guid.NewGuid(), 
                Name = "Test", 
                Surname = "TestSurname",
                Patronym = null,
                NickName = "TestNickname",
                Email = "test@devrelcrm.com",
                Password = "passwrod",
                Role = null,
                DateAdded = DateTime.Now,

            }

        };

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            // Application Commands
        }
    }
}
