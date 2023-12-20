using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevRelCRM.Infrastructure.Database.MongoDB.Habr.Services
{
    public interface IMongoSaveService
    {
        /// <summary>
        /// Асинхронно сохраняет коллекцию данных в указанную базу данных MongoDB.
        /// </summary>
        /// <typeparam name="T">Тип данных для сохранения.</typeparam>
        /// <param name="items">Коллекция данных для сохранения.</param>
        /// <param name="databaseName">Имя базы данных.</param>
        /// <returns>Задача, представляющая асинхронный процесс сохранения данных.</returns>
        Task SaveAsync<T>(IEnumerable<T> items, string databaseName);
    }
}
