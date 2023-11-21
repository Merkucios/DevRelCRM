using AutoMapper;
using DevRelCRM.Application.Mappings;
using DevRelCRM.Application.Users.Commands;

namespace DevRelCRM.WebAPI.DataTransferObjects
{
    public class CreateUserDTO : IMapWith<CreateUserCommand>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronym { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDTO, CreateUserCommand>()
                .ForMember(userCommand => userCommand.Name,
                    opt => opt.MapFrom(userDto => userDto.Name))
                .ForMember(userCommand => userCommand.Surname,
                    opt => opt.MapFrom(userDto => userDto.Surname))
                .ForMember(userCommand => userCommand.Patronym,
                    opt => opt.MapFrom(userDto => userDto.Patronym))
                .ForMember(userCommand => userCommand.NickName,
                    opt => opt.MapFrom(userDto => userDto.NickName))
                .ForMember(userCommand => userCommand.Email,
                    opt => opt.MapFrom(userDto => userDto.Email))
                .ForMember(userCommand => userCommand.Password,
                    opt => opt.MapFrom(userDto => userDto.Password))
                .ForMember(userCommand => userCommand.Role,
                    opt => opt.MapFrom(userDto => userDto.Role));


        }
    }
}
