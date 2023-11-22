using DevRelCRM.Application.Mappings;
using DevRelCRM.Application.Users.Commands.UpdateUser;
using AutoMapper;

namespace DevRelCRM.WebAPI.DataTransferObjects
{
    public class UpdateUserDTO : IMapWith<UpdateUserCommand>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronym { get; set; }
        public string? Role { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserDTO, UpdateUserCommand>()
                .ForMember(userUpdate => userUpdate.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(userUpdate => userUpdate.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(userUpdate => userUpdate.Patronym, opt => opt.MapFrom(src => src.Patronym))
                .ForMember(userUpdate => userUpdate.Role, opt => opt.MapFrom(src => src.Role));
        }
    }
}
