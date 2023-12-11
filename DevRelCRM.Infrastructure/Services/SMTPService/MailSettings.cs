namespace DevRelCRM.Infrastructure.Services.SMTPService
{
    /// <summary>
    /// Класс, представляющий настройки для подключения к почтовому серверу.
    /// </summary>
    public class MailSettings
    {
        /// <summary>
        /// Задает отображаемое имя отправителя, которое будет отображаться у получателя.
        /// </summary>
        public string? DisplayName { get; set; }

        /// <summary>
        /// Задает адрес отправителя, который будет использоваться как отправитель писем.
        /// </summary>
        public string? From { get; set; }

        /// <summary>
        /// Задаёт имя пользователя, используемое для аутентификации на почтовом сервере.
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Задаёт пароль, используемый для аутентификации на почтовом сервере.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Задаёт адрес почтового сервера.
        /// </summary>
        public string? Host { get; set;}

        /// <summary>
        ///  Задает порт почтового сервера.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Задает значение, указывающее, следует ли использовать SSL для безопасного подключения к серверу.
        /// </summary>
        public bool UseSSL { get; set; }

        /// <summary>
        /// Задаёт значение, указывающее, следует ли использовать TLS для безопасного подключения к серверу.
        /// </summary>
        public bool UseTLS { get; set; }

    }
}
