using AutoMapper;

namespace DevRelCRM.Application.Mappings
{
    /// <summary>
    /// Интерфейс для объектов, предназначенных для маппинга с использованием AutoMapper.
    /// </summary>
    /// <typeparam name="T">Тип объекта, с которого осуществляется маппинг.</typeparam>
    public interface IMapWith<T>
    {
        /// <summary>
        /// Метод для определения маппинга с помощью переданного профиля AutoMapper.
        /// </summary>
        /// <param name="profile">Профиль AutoMapper, используемый для создания маппинга.</param>
        void Mapping(Profile profile) => 
            profile.CreateMap(typeof(T), GetType());
    }
}   
