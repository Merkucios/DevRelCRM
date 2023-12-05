using DevRelCRM.Application.Users.Commands.LoginUser; using FluentValidation; using FluentValidation.Results; using MediatR; using Microsoft.AspNetCore.Authorization; using Microsoft.AspNetCore.Mvc; using Microsoft.AspNetCore.Mvc.RazorPages;  namespace DevRelCRM.WebAuth.Pages {     [AllowAnonymous]     public class LoginModel : PageModel     {         // Mediator используется для отправки и получения сообщений (команд и запросов) между объектами         private readonly IMediator _mediator;         // Валидатор для CreateUserCommand, предназначенный для валидации ввода пользователя         private readonly IValidator<LoginUserCommand> _validator;          [BindProperty]         public LoginUserCommand Input { get; set; }          public LoginModel(IMediator mediator, IValidator<LoginUserCommand> validator)         {             _mediator = mediator;             _validator = validator;         }           public void OnGet()         {          }          public async Task<IActionResult> OnPostAsync()         {
            ValidationResult validationResult = await _validator.ValidateAsync(Input);             if (validationResult.IsValid)
            {
                // Отправка команды на получение JWT токена
                string jwtToken = await _mediator.Send(Input);
                if (!string.IsNullOrEmpty(jwtToken))
                {
                    // Установка JWT токена в куки и перенаправление на страницу регистрации
                    Response.Cookies.Append("jwtToken", jwtToken);
                    await Console.Out.WriteLineAsync($"Токен: " + jwtToken);
                    return Redirect("http://localhost:3000/");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Внутренняя ошибка сервера при генерации токена.");
                }

            }
            return Page();         }       } } 