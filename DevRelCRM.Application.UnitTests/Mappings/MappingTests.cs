using AutoMapper;
using DevRelCRM.Application;
using DevRelCRM.Core.DomainModels;
using DevRelCRM.Infrastructure.Database.PostgreSQL;
using DevRelCRM.Application.Users;
using System.Reflection;
using System.Runtime.Serialization;
using DevRelCRM.Application.Users.Queries;

namespace DevRelCRM.Application.UnitTests.Mappings
{
    // Класс для тестирования маппинга с использованием AutoMapper и MediatR
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(config =>
            config.AddMaps(Assembly.GetAssembly(typeof(ApplicationDbContext))));

            _mapper = _configuration.CreateMapper();
        }

        // Тест для проверки корректности конфигурации маппинга
        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Test]
        [TestCase(typeof(UserDetailsVm), typeof(User))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            // Получаем экземпляр объекта указанного типа
            var instance = GetInstanceOf(source);

            _mapper.Map(instance, source, destination);
        }

        // Метод для создания экземпляра объекта указанного типа
        private object GetInstanceOf(Type type)
        {
            // Проверяем наличие публичного конструктора без параметров
            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type)!;

            // Если конструктор отсутствует, используем FormatterServices для создания неинициализированного объекта
            return FormatterServices.GetUninitializedObject(type);
        }
    }
}
