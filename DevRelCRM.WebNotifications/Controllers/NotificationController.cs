using DevRelCRM.Infrastructure.Services.SMTPService; using DevRelCRM.Infrastructure.Services.SMTPService.TemplateModels; using Microsoft.AspNetCore.Mvc; using System.IO.Pipelines;  namespace DevRelCRM.WebNotifications.Controllers {     [Route("/api/v1/[controller]")]     [ApiController]     public class NotificationController : Controller     {         private readonly IEmailService _emailService;          public NotificationController(IEmailService emailService)         {             _emailService = emailService;         }          [HttpPost("send-email")]         [ProducesResponseType(StatusCodes.Status200OK)]         [ProducesResponseType(StatusCodes.Status500InternalServerError)]         public async Task<IActionResult> SendMailAsync(MailData mailData)         {             bool result = await _emailService.SendEmailAsync(mailData, new CancellationToken());              if (result)             {                 return StatusCode(StatusCodes.Status200OK, "Письмо было успешно отправлено.");             }             else             {                 return StatusCode(StatusCodes.Status500InternalServerError, "Произошла ошибка. Письмо не отправлено.");             }         }          [HttpPost("send-email-with-attachment")]         [ProducesResponseType(StatusCodes.Status200OK)]         [ProducesResponseType(StatusCodes.Status500InternalServerError)]         public async Task<IActionResult> SendMailWithAttachmentAsync([FromForm] MailDataWithAttachments mailDataWithAttachments)
        {
            bool result = await _emailService.SendEmailWithAttachmentsAsync(mailDataWithAttachments, new CancellationToken());
            if (result)             {
                return StatusCode(StatusCodes.Status200OK, "Письмо со вложениями было успешно отправлено.");
            }             else             {
                return StatusCode(StatusCodes.Status500InternalServerError, "Произошла ошибка. Письмо не отправлено.");
            }
        }          [HttpPost("send-email-using-template")]         [ProducesResponseType(StatusCodes.Status200OK)]         [ProducesResponseType(StatusCodes.Status500InternalServerError)]         public async Task<IActionResult> SendEmailUsingTemplate(WelcomeMailModel welcomeMail)
        {
            MailData mailData = new MailData
                (
                    new List<string> { welcomeMail.Email },
                    "Добро пожаловать в DevRelCRM ❣",
                    _emailService.GetEmailTemplate(TypeTemplateConstraints.WELCOME_TEMPLATE, welcomeMail)
                );

            bool result = await _emailService.SendEmailAsync(mailData, new CancellationToken());

            if (result)
            {
                return StatusCode(StatusCodes.Status200OK, "Сообщение с использованием шаблона успешно отправлено");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Произошла ошибка. Письмо не отправлено.");
            }
        }      } } 