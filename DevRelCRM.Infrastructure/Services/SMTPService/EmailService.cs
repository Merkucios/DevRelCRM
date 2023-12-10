using System.Reflection; using MailKit; using MailKit.Net.Smtp; using MailKit.Security; using Microsoft.AspNetCore.Http; using Microsoft.Extensions.Options; using MimeKit; using RazorEngineCore; using System.Text;  namespace DevRelCRM.Infrastructure.Services.SMTPService {
    /// <summary>
    /// Сервис электронной почты для отправки писем через службу SMTP.
    /// </summary>     public class EmailService : IEmailService     {
        private readonly MailSettings _settings;

        public EmailService(IOptions<MailSettings> settings)
        {
            _settings = settings.Value;
        }

        /// <summary>
        /// Отправляет электронное письмо с возможностью прикрепления файлов.
        /// </summary>
        /// <param name="mailData">Данные письма с прикрепленными файлами.</param>
        /// <param name="cancellationToken">Токен отмены операции (по умолчанию - default).</param>
        /// <returns>True, если письмо успешно отправлено; в противном случае - false.</returns>
        public async Task<bool> SendEmailWithAttachmentsAsync(MailDataWithAttachments mailData, CancellationToken cancellationToken = default)
        {
            try
            {
                var mail = CreateMimeMessage(mailData);
                #region Отправка письма

                using var smtp = new SmtpClient();

                await ConfigureSmtpClientAsync(smtp, cancellationToken);

                await smtp.AuthenticateAsync(_settings.UserName, _settings.Password, cancellationToken);
                await smtp.SendAsync(mail, cancellationToken);
                await smtp.DisconnectAsync(true, cancellationToken);

                return true;
                #endregion

            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Отправляет электронное письмо.
        /// </summary>
        /// <param name="mailData">Данные письма.</param>
        /// <param name="cancellationToken">Токен отмены операции (по умолчанию - default).</param>
        /// <returns>True, если письмо успешно отправлено; в противном случае - false.</returns>
        public async Task<bool> SendEmailAsync(MailData mailData, CancellationToken cancellationToken = default)
        {
            try
            {
                var mail = CreateMimeMessage(mailData);
                #region Отправка письма
                using var smtp = new SmtpClient();

                await ConfigureSmtpClientAsync(smtp, cancellationToken);

                await smtp.AuthenticateAsync(_settings.UserName, _settings.Password, cancellationToken);
                await smtp.SendAsync(mail, cancellationToken);
                await smtp.DisconnectAsync(true, cancellationToken);
                #endregion

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Получает содержимое электронного шаблона для указанного шаблона и модели.
        /// </summary>
        /// <typeparam name="T">Тип модели для электронного шаблона.</typeparam>
        /// <param name="emailTemplate">Имя электронного шаблона.</param>
        /// <param name="emailTemplateModel">Модель для электронного шаблона.</param>
        /// <returns>Содержимое электронного шаблона.</returns>
        public string GetEmailTemplate<T>(string emailTemplate, T emailTemplateModel)
        {
            // Загружаем шаблон по имени
            string mailTemplate = LoadTemplate(emailTemplate);

            // Инициализируем движок Razor и компилируем шаблон
            IRazorEngine razorEngine = new RazorEngine();
            IRazorEngineCompiledTemplate modifiedMailTemplate = razorEngine.Compile(mailTemplate);

            // Запускаем скомпилированный шаблон с переданной моделью
            return modifiedMailTemplate.Run(emailTemplateModel);
        }

        /// <summary>
        /// Загружает содержимое электронного шаблона по его имени.
        /// </summary>
        /// <param name="emailTemplate">Имя электронного шаблона.</param>
        /// <returns>Содержимое электронного шаблона.</returns>
        public string LoadTemplate(string emailTemplate)
        {
            // Получаем текущую директорию проекта (WebNotifications)
            string baseDir = Directory.GetCurrentDirectory();

            // Получаем директорию выше текущей (DevRelCRM)
            string topDir = Directory.GetParent(baseDir).ToString();

            // Формируем путь к директории с шаблонами
            string templateDir = Path.Combine(topDir, "DevRelCRM.Infrastructure", "Services", "SMTPService", "WebTemplates");

            // Формируем полный путь к файлу шаблона
            string templatePath = Path.Combine(templateDir, $"{emailTemplate}.cshtml");

            // Открываем файл шаблона и считываем его содержимое
            using FileStream fileStream = new FileStream(templatePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);

            string mailTemplate = streamReader.ReadToEnd();
            streamReader.Close();

            return mailTemplate;
        }

        private MimeMessage CreateMimeMessage(MailData mailData)
        {
            // Инициализация нового экземпляра класса MimeKit.MimeMessage
            var mail = new MimeMessage();

            #region Отправитель / Получатель
            // Отправитель
            mail.From.Add(new MailboxAddress(_settings.DisplayName, mailData.From ?? _settings.From));
            mail.Sender = new MailboxAddress(mailData.DisplayName ?? _settings.DisplayName, mailData.From ?? _settings.From);

            // Получатель
            foreach (string mailAddress in mailData.To)
                mail.To.Add(MailboxAddress.Parse(mailAddress));

            // Установка адреса для ответа, если указано в данных письма
            if (!string.IsNullOrEmpty(mailData.ReplyTo))
                mail.ReplyTo.Add(new MailboxAddress(mailData.ReplyToName, mailData.ReplyTo));

            #endregion

            // Скрытые копии
            // Проверка, были ли указаны адреса для скрытых копий в запросе
            AddRecipients(mailData.Bcc, mail.Bcc);

            // Копии
            // Проверка, был ли указан адрес для копии в запросе
            AddRecipients(mailData.Cc, mail.Cc);

            #region Содержимое

            // Добавление содержимого в сообщение Mime
            var body = new BodyBuilder();
            mail.Subject = mailData.Subject;
            body.HtmlBody = mailData.Body;
            mail.Body = body.ToMessageBody();

            #endregion
            return mail;
        }

        private MimeMessage CreateMimeMessage(MailDataWithAttachments mailData)
        {
            // Инициализация экземпляра класса MimeKit.MimeMessage
            var mail = new MimeMessage();

            #region Отправитель / Получатель
            // Отправитель
            mail.From.Add(new MailboxAddress(_settings.DisplayName, mailData.From ?? _settings.From));
            mail.Sender = new MailboxAddress(mailData.DisplayName ?? _settings.DisplayName, mailData.From ?? _settings.From);

            // Получатель
            foreach (string mailAddress in mailData.To)
                mail.To.Add(MailboxAddress.Parse(mailAddress));

            // Установка адреса для ответа, если указано в данных письма
            if (!string.IsNullOrEmpty(mailData.ReplyTo))
                mail.ReplyTo.Add(new MailboxAddress(mailData.ReplyToName, mailData.ReplyTo));

            // Скрытые копии
            // Проверка, были ли указаны адреса для скрытых копий в запросе
            AddRecipients(mailData.Bcc, mail.Bcc);

            // Копии
            // Проверка, был ли указан адрес для копии в запросе
            AddRecipients(mailData.Cc, mail.Cc);
            #endregion

            #region Содержимое

            // Добавление содержимого в сообщение Mime
            var body = new BodyBuilder();
            mail.Subject = mailData.Subject;

            // Проверка, есть ли прикрепленные файлы, и добавление их в конструктор сообщения
            if (mailData.Attachments != null)
            {
                byte[] attachmentFileByteArray;
                foreach (IFormFile attachment in mailData.Attachments)
                {
                    if (attachment.Length > 0)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            attachment.CopyTo(memoryStream);
                            attachmentFileByteArray = memoryStream.ToArray();
                        }
                        body.Attachments.Add(attachment.FileName, attachmentFileByteArray, ContentType.Parse(attachment.ContentType));
                    }
                }
            }
            body.HtmlBody = mailData.Body;
            mail.Body = body.ToMessageBody();

            return mail;
            #endregion
        }

        private void AddRecipients(List<string>? recipients, InternetAddressList list)
        {
            if (recipients != null)
            {
                foreach (string mailAddress in recipients.Where(x => !string.IsNullOrWhiteSpace(x)))
                {
                    list.Add(MailboxAddress.Parse(mailAddress.Trim()));
                }
            }
        }

        private async Task ConfigureSmtpClientAsync(SmtpClient smtp, CancellationToken cancellationToken)
        {
            if (_settings.UseSSL)
            {
                await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.SslOnConnect, cancellationToken);
            }
            else if (_settings.UseTLS)
            {
                await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls, cancellationToken);
            }
        }
    }
}