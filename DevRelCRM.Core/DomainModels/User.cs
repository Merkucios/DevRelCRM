namespace DevRelCRM.Core.DomainModels
{
    // Модель данных, представляющая пользователя в системе
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronym { get; set; }
        public string Gender { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
        public DateTime DateCreated { get; set; }

        
    }
}
