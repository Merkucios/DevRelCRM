namespace DevRelCRM.Infrastructure.Services.SMTPService
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
