using AutoMapper;
using System.Reflection;

namespace DevRelCRM.Application.Mappings
{
    /// <summary>
    /// Профиль маппинга, основанный на сборке.
    /// </summary>
    public class AssemblyMappingProfile : Profile
    {
        /// <summary>
        /// Конструктор класса, принимающий сборку и применяющий маппинги из нее.
        /// </summary>
        /// <param name="assembly">Сборка, содержащая типы для маппинга.</param>
        public AssemblyMappingProfile(Assembly assembly) =>
            ApplyMappingsFromAssembly(assembly);

        /// <summary>
        /// Метод для применения маппингов из указанной сборки.
        /// </summary>
        /// <param name="assembly">Сборка, содержащая типы для маппинга.</param>
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            // Получаем все открытые типы из сборки
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                    .Any(i => i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            // Для каждого типа, реализующего интерфейс IMapWith<>
            foreach (var type in types)
            {
                // Создаем экземпляр объекта
                var instance = Activator.CreateInstance(type);

                // Получаем метод "Mapping" у объекта и вызываем его,
                // передавая текущий профиль маппинга в качестве параметра
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
