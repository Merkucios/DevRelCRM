using AutoMapper;

namespace DevRelCRM.WebAPI.Mappings
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) => 
            profile.CreateMap(typeof(T), GetType());
    }
}   
