using Serilog;
using AutoMapper;
using DevRelCRM.Application.Users.Queries;
using DevRelCRM.Application.Users.Commands.CreateUser;
using DevRelCRM.Application.Users.Commands.DeleteUser;
using DevRelCRM.WebAPI.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using MediatR;

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

        // <summary>
        /// Конструктор контроллера пользователя.
        /// </summary>
        /// <param name="mapper">Маппер для преобразования объектов.</param>
        /// <param name="mediator">MediatR для обработки запросов и команд.</param>
        /// <param name="logger">Логгер для записи информации о действиях контроллера.</param>
        public UserController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        /// <summary>
        /// Получить детали пользователя по идентификатору.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Детали пользователя в формате UserDetailsVm.</returns>
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDetailsVm>> GetUserDetails(Guid userId)
        {
            Log.Information($"Запрошены детали пользователя с идентификатором {userId}");

            var query = new GetUserDetailsQuery { UserId = userId };
            var userDetails = await _mediator.Send(query);

            if (userDetails == null)
            {
                Log.Warning($"Пользователь с идентификатором {userId} не найден");
                return NotFound();
            }

            Log.Information($"Детали пользователя с идентификатором {userId} успешно получены");
            return Ok(userDetails);
        }

        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="createUserDTO">DTO для создания пользователя.</param>
        /// <returns>Идентификатор нового пользователя.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            try
            {
                Log.Information($"Запрос на создание нового пользователя: {createUserDTO}");

                var command = _mapper.Map<CreateUserCommand>(createUserDTO);
                var userId = await _mediator.Send(command);

                Log.Information($"Пользователь успешно создан. Идентификатор: {userId}");
                return Ok(userId);
            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка при создании пользователя: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Внутренняя ошибка сервера");
            }

        }

        /// <summary>
        /// Удаляет пользователя по указанному идентификатору.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя для удаления.</param>
        /// <returns>Возвращает NoContent в случае успешного удаления. В случае ошибки возвращает соответствующий статус и сообщение об ошибке.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            try
            {
                Log.Information($"Запрос на удаление пользователя с идентификатором: {userId}");

                var command = new DeleteUserCommand
                {
                    UserId = userId
                };

                await _mediator.Send(command);

                Log.Information($"Пользователь с идентификатором {userId} успешно удален");
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error($"Ошибка при удалении пользователя: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Внутренняя ошибка сервера");
            }

        }
    }
}
