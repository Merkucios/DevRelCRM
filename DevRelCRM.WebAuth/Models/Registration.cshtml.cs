using DevRelCRM.Application.Users.Commands.CreateUser; using DevRelCRM.Infrastructure.Services.SMTPService.TemplateModels; using System.Text; using System.Text.Encodings; using FluentValidation; using FluentValidation.Results; using MediatR; using Microsoft.AspNetCore.Authorization; using Microsoft.AspNetCore.Mvc; using Microsoft.AspNetCore.Mvc.RazorPages; using Newtonsoft.Json;  namespace DevRelCRM.WebAuth.Pages {     [AllowAnonymous]      //  Модель Razor-страницы для регистрации пользователя     public class RegistrationModel : PageModel     {         // Mediator используется для отправки и получения сообщений (команд и запросов) между объектами         private readonly IMediator _mediator;          // Валидатор для CreateUserCommand, предназначенный для валидации ввода пользователя         private readonly IValidator<CreateUserCommand> _validator;          // Свойство модели для привязки ввода пользователя из формы регистрации         [BindProperty]         public CreateUserCommand Input { get; set; }          public RegistrationModel(IMediator mediator, IValidator<CreateUserCommand> validator)         {             _mediator = mediator;             _validator = validator;         }          public void OnGet()         {          }          public async Task<IActionResult> OnPostAsync()         {              ValidationResult validationResult = await _validator.ValidateAsync(Input);              if (validationResult.IsValid)             {                 var userId = await _mediator.Send(Input);                  using (HttpClient client = new HttpClient())
                {
                    var apiUrl = "https://localhost:7021/api/v1/Notification/send-welcome-email";
                    WelcomeMailModel postData = new WelcomeMailModel                     {                         Name = Input.Name,
                        Email = Input.Email                     };                      string jsonContent = JsonConvert.SerializeObject(postData);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");                      try
                    {
                        var response = await client.PostAsync(apiUrl, content);

                        response.EnsureSuccessStatusCode();

                    }
                    catch (HttpRequestException ex)
                    {
                        await Console.Out.WriteLineAsync($"Error: {ex.Message}");
                    }
                }                  Task.Delay(3000).Wait();                 return Redirect("http://localhost:3000/");             }              await Console.Out.WriteLineAsync(validationResult.IsValid.ToString());             return Page();         }      } } 