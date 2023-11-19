namespace DevRelCRM.WebAPI.DataTransferObjects
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronym { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string? Role { get; set; }
    }
}
