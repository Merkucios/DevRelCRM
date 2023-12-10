namespace DevRelCRM.Infrastructure.Services.SMTPService
{
    /// <summary>
    /// Класс, представляющий данные электронного письма для отправки через службу SMTP.
    /// </summary>
    public class MailData
    {
        /// <summary>
        /// Получает список адресатов (To) письма.
        /// </summary>
        public List<string> To { get; }

        /// <summary>
        /// Получает список скрытых копий адресатов (Bcc) письма.
        /// </summary>
        public List<string> Bcc { get; }

        /// <summary>
        /// Получает список копий адресатов (Cc) письма.
        /// </summary>
        public List<string> Cc { get; }

        /// <summary>
        /// Получает или задает адрес отправителя (From) письма.
        /// </summary>
        public string? From { get; }

        /// <summary>
        /// Получает или задает отображаемое имя отправителя (DisplayName) письма.
        /// </summary>
        public string? DisplayName { get; }

        /// <summary>
        /// Получает или задает адрес для ответа (ReplyTo) письма.
        /// </summary>
        public string? ReplyTo { get; }

        /// <summary>
        /// Получает или задает отображаемое имя для ответа (ReplyToName) письма.
        /// </summary>
        public string? ReplyToName { get; }

        /// <summary>
        /// Получает или задает тему (Subject) письма.
        /// </summary>
        public string Subject { get; }

        /// <summary>
        /// Получает или задает тело (Body) письма.
        /// </summary>
        public string? Body { get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса MailData с указанными параметрами.
        /// </summary>
        /// <param name="to">Список адресатов (To) письма.</param>
        /// <param name="subject">Тема (Subject) письма.</param>
        /// <param name="body">Тело (Body) письма (по умолчанию - null).</param>
        /// <param name="from">Адрес отправителя (From) письма (по умолчанию - null).</param>
        /// <param name="displayName">Отображаемое имя отправителя (DisplayName) письма (по умолчанию - null).</param>
        /// <param name="replyTo">Адрес для ответа (ReplyTo) письма (по умолчанию - null).</param>
        /// <param name="replyToName">Отображаемое имя для ответа (ReplyToName) письма (по умолчанию - null).</param>
        /// <param name="bcc">Список скрытых копий адресатов (Bcc) письма (по умолчанию - null).</param>
        /// <param name="cc">Список копий адресатов (Cc) письма (по умолчанию - null).</param>
        public MailData(List<string> to, string subject, string? body = null, string? from = null, string? displayName = null, string? replyTo = null, string? replyToName = null, List<string>? bcc = null, List<string>? cc = null)
        {
            To = to;
            Bcc = bcc ?? new List<string>();
            Cc = cc ?? new List<string>();

            From = from;
            DisplayName = displayName;
            ReplyTo = replyTo;
            ReplyToName = replyToName;

            Subject = subject;
            Body = body;
        }
    }
}
