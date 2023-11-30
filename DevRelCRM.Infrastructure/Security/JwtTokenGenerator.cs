using DevRelCRM.Core.DomainModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DevRelCRM.Infrastructure.Security
{
    public class JwtTokenGenerator
    {
        private readonly IConfiguration _configuration;

        // Конструктор, принимающий IConfiguration для доступа к конфигурационным данным
        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Метод для генерации JWT токена на основе информации о пользователе
        public string GenerateToken(User user)
        {
            // Создание списка утверждений (claims), которые будут включены в токен
                // Роль пользователя сделана с логикой , что 1 юзер = 1 роль на платформе
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.NickName),
                new Claim(ClaimTypes.Role, user.Role),
            };

            // Получение секретного ключа для подписи токена из конфигурации
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("JwtSettings:SecretKey").Value!));

            // Создание учетных данных для подписи токена
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // Создание JWT токена с учетом утверждений, времени жизни и учетных данных
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );
           
            // Преобразование JWT токена в строку
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
