using DevRelCRM.Application.Users.Queries;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using DevRelCRM.Application.Users.Commands;
using DevRelCRM.WebAPI.DataTransferObjects;
using AutoMapper;

namespace DevRelCRM.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер для управления пользователями.
    /// </summary>
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        // <summary>
        /// Конструктор контроллера пользователя.
        /// </summary>
        /// <param name="mapper">Маппер для преобразования объектов.</param>
        /// <param name="mediator">MediatR для обработки запросов и команд.</param>
        /// <param name="logger">Логгер для записи информации о действиях контроллера.</param>
        public UserController(IMapper mapper, IMediator mediator, ILogger<UserController> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }
        /// <summary>
        /// Получить детали пользователя по идентификатору.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Детали пользователя в формате UserDetailsVm.</returns>
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

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="createUserDTO">DTO для создания пользователя.</param>
        /// <returns>Идентификатор нового пользователя.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            var command = _mapper.Map<CreateUserCommand>(createUserDTO);
            var userId = await _mediator.Send(command);
            return Ok(userId);
            
        }
    }
}
