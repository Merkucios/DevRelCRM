namespace DevRelCRM.Infrastructure.Services.SMTPService
{
    /// <summary>
    /// Интерфейс для службы отправки электронных писем через службу SMTP.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Отправляет электронное письмо.
        /// </summary>
        /// <param name="mailData">Данные письма.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>True, если письмо успешно отправлено; в противном случае - false.</returns>
        Task<bool> SendEmailAsync(MailData mailData, CancellationToken cancellationToken);

        /// <summary>
        /// Отправляет электронное письмо с возможностью прикрепления файлов.
        /// </summary>
        /// <param name="mailData">Данные письма с прикрепленными файлами.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>True, если письмо успешно отправлено; в противном случае - false.</returns>
        Task<bool> SendEmailWithAttachmentsAsync(MailDataWithAttachments mailData, CancellationToken cancellationToken);
    }
}
