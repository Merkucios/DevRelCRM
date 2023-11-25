using DevRelCRM.Application.Users.Commands.CreateUser;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevRelCRM.WebAuth.Pages
{
    //  Модель Razor-страницы для регистрации пользователя
    public class RegistrationModel : PageModel
    {
        // Mediator используется для отправки и получения сообщений (команд и запросов) между объектами
        private readonly IMediator _mediator;

        // Валидатор для CreateUserCommand, предназначенный для валидации ввода пользователя
        private readonly IValidator<CreateUserCommand> _validator;

        // Свойство модели для привязки ввода пользователя из формы регистрации
        [BindProperty]
        public CreateUserCommand Input { get; set; }

        public RegistrationModel(IMediator mediator, IValidator<CreateUserCommand> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
             ValidationResult validationResult = await _validator.ValidateAsync(Input);

            if (validationResult.IsValid)
            {
                var userId = await _mediator.Send(Input);
                Console.WriteLine($"{userId}");
                Task.Delay(3000).Wait();
                return RedirectToPage("/Index");
            }

            await Console.Out.WriteLineAsync(validationResult.IsValid.ToString());
            return Page();
        }

    }
}
