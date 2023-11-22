using AutoMapper;
using DevRelCRM.Application.Mappings;
using DevRelCRM.Application.Users.Commands.CreateUser;

namespace DevRelCRM.WebAPI.DataTransferObjects
{
    /// <summary>
    /// Data Transfer Object (DTO) для создания нового пользователя.
    /// Реализует интерфейс IMapWith для маппинга с объектом CreateUserCommand.
    /// </summary>
    public class CreateUserDTO : IMapWith<CreateUserCommand>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronym { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string? Role { get; set; }

        /// <summary>
        /// Метод маппинга объекта CreateUserDTO на CreateUserCommand с использованием AutoMapper.
        /// </summary>
        /// <param name="profile">Профиль AutoMapper, используемый для создания маппинга.</param>
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
                .ForMember(userCommand => userCommand.Role,
                    opt => opt.MapFrom(userDto => userDto.Role));


        }
    }
}
