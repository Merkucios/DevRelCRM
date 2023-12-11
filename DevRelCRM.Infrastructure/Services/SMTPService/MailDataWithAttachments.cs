using Microsoft.AspNetCore.Http;

namespace DevRelCRM.Infrastructure.Services.SMTPService
{
    /// <summary>
    /// Класс, представляющий данные электронного письма с возможностью прикрепления файлов для отправки через службу SMTP.
    /// </summary>
    public class MailDataWithAttachments
    {
        /// <summary>
        /// Получает или задает список адресатов (To) письма.
        /// </summary>
        public List<string>? To { get; set; }

        /// <summary>
        /// Получает или задает список скрытых копий адресатов (Bcc) письма.
        /// </summary>
        public List<string>? Bcc { get; set; }

        /// <summary>
        /// Получает или задает список копий адресатов (Cc) письма.
        /// </summary>
        public List<string>? Cc { get; set; }

        /// <summary>
        /// Получает или задает адрес отправителя (From) письма.
        /// </summary>
        public string? From { get; set; }

        /// <summary>
        /// Получает или задает отображаемое имя отправителя (DisplayName) письма.
        /// </summary>
        public string? DisplayName { get; set; }

        /// <summary>
        /// Получает или задает адрес для ответа (ReplyTo) письма.
        /// </summary>
        public string? ReplyTo { get; set; }

        /// <summary>
        /// Получает или задает отображаемое имя для ответа (ReplyToName) письма.
        /// </summary>
        public string? ReplyToName { get; set; }

        /// <summary>
        /// Получает или задает тему (Subject) письма.
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// Получает или задает тело (Body) письма.
        /// </summary>
        public string? Body { get; set; }

        /// <summary>
        /// Получает или задает коллекцию файлов, прикрепленных к письму.
        /// </summary>
        public IFormFileCollection? Attachments { get; set; }
    }
}
