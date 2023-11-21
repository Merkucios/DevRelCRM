using AutoMapper;
using DevRelCRM.Application.Mappings;
using DevRelCRM.Core.DomainModels;

namespace DevRelCRM.Application.Users.Queries
{
    public class UserDetailsVm : IMapWith<User>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronym { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string? Role { get; set; }

        public DateTime DateCreated { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVm>()
                .ForMember(userVm => userVm.UserId, opt => opt.MapFrom(user => user.UserId))
                .ForMember(userVm => userVm.Name, opt => opt.MapFrom(user => user.Name))
                .ForMember(userVm => userVm.Surname, opt => opt.MapFrom(user => user.Surname))
                .ForMember(userVm => userVm.Patronym, opt => opt.MapFrom(user => user.Patronym))
                .ForMember(userVm => userVm.NickName, opt => opt.MapFrom(user => user.NickName))
                .ForMember(userVm => userVm.Email, opt => opt.MapFrom(user => user.Email))
                .ForMember(userVm => userVm.Role, opt => opt.MapFrom(user => user.Role))
                .ForMember(userVm => userVm.DateCreated, opt => opt.MapFrom(user => user.DateCreated));
        }
    }
}
