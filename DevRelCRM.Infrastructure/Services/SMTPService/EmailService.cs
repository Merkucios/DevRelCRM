/* Добавить MailKit для SMTP-сервера
 * Создать почту для проекта на yandex.ru
 * smtp.yandxex.ru (SSL) порт 465 */

namespace DevRelCRM.Infrastructure.Services.SMTPService
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string to, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
