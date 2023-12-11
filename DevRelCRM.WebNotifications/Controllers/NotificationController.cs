using System;
using Serilog;
using DevRelCRM.Infrastructure.Services.SMTPService;
using DevRelCRM.Infrastructure.Services.SMTPService.TemplateModels;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Pkcs;

namespace DevRelCRM.WebNotifications.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class NotificationController : Controller
    {
        private readonly IEmailService _emailService;

        public NotificationController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send-email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SendMailAsync(MailData mailData)
        {
            try
            {
                bool result = await _emailService.SendEmailAsync(mailData, new CancellationToken());
                if (result)
                {
                    Log.Information("Письмо было успешно отправлено.");
                    return StatusCode(StatusCodes.Status200OK, "Письмо было успешно отправлено.");
                }
                else
                {
                    Log.Error("Произошла ошибка. Письмо не отправлено.");
                    return StatusCode(StatusCodes.Status500InternalServerError, "Произошла ошибка. Письмо не отправлено.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при отправке письма.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Произошла ошибка. Письмо не отправлено.");
            }
        }

        [HttpPost("send-email-with-attachment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SendMailWithAttachmentAsync([FromForm] MailDataWithAttachments mailDataWithAttachments)
        {

            try
            {
                bool result = await _emailService.SendEmailWithAttachmentsAsync(mailDataWithAttachments, new CancellationToken());
                if (result)
                {
                    Log.Information("Письмо c вложениями было успешно отправлено.");
                    return StatusCode(StatusCodes.Status200OK, "Письмо со вложениями было успешно отправлено.");
                }
                else
                {
                    Log.Error("Произошла ошибка. Письмо c вложениями не отправлено.");
                    return StatusCode(StatusCodes.Status500InternalServerError, "Произошла ошибка. Письмо не отправлено.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при отправке письма с вложениями.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Произошла ошибка. Письмо не отправлено.");
            }
        }

        [HttpPost("send-welcome-email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SendEmailUsingTemplate(WelcomeMailModel welcomeMail)
        {
            try
            {
                MailData mailData = new MailData(
                    new List<string> { welcomeMail.Email },
                    "Добро пожаловать в DevRelCRM ❣",
                    _emailService.GetEmailTemplate(TypeTemplateConstraints.WELCOME_TEMPLATE, welcomeMail)
                );

                bool result = await _emailService.SendEmailAsync(mailData, new CancellationToken());

                if (result)
                {
                    Log.Information("Сообщение с использованием шаблона успешно отправлено");
                    return StatusCode(StatusCodes.Status200OK, "Сообщение с использованием шаблона успешно отправлено");
                }
                else
                {
                    Log.Error("Произошла ошибка. Письмо не отправлено.");
                    return StatusCode(StatusCodes.Status500InternalServerError, "Произошла ошибка. Письмо не отправлено.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка при отправке письма с использованием шаблона.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Произошла ошибка. Письмо не отправлено.");
            }
        }
    }
}
