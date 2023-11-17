using System;
using System.Collections.Generic;

namespace DevRelCRM.Core.DomainModels
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronym { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }

        public User(int id, string name, string surname, string? patronym, string nickName, string email, string password, string? role)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Patronym = patronym;
            NickName = nickName;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
