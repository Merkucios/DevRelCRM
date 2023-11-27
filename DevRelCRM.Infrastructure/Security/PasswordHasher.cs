namespace DevRelCRM.Infrastructure.Security
{
    /// <summary>
    /// Предоставляет методы для хеширования и проверки паролей с использованием BCrypt.
    /// </summary>
    public static class PasswordHasher
    {
        /// <summary>
        /// Хеширует пароль в открытом виде с использованием BCrypt и случайно сгенерированной соли.
        /// </summary>
        /// <param name="password">Пароль в открытом виде для хеширования.</param>
        /// <returns>Хешированный пароль в виде строки.</returns
        public static string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
            return hashedPassword;
        }

        /// <summary>
        /// Проверяет, соответствует ли введенный пароль хешированному паролю.
        /// </summary>
        /// <param name="password">Введенный пароль для проверки.</param>
        /// <param name="hashedPassword">Хешированный пароль, с которым сравнивается введенный пароль.</param>
        /// <returns>True, если пароль совпадает, иначе False.</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
