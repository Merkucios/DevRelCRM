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

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Test]
        [TestCase(typeof(UserDetailsVm), typeof(User))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = GetInstanceOf(source);

            _mapper.Map(instance, source, destination);
        }

        private object GetInstanceOf(Type type)
        {
            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type)!;

            return FormatterServices.GetUninitializedObject(type);
        }
    }
}
