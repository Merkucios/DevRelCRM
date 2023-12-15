using MongoDB.Driver;

namespace DevRelCRM.Infrastructure.Database.MongoDB.Habr.Services
{
    /// <summary>
    /// Сервис для сохранения данных в MongoDB.
    /// </summary>
    public class MongoDbSaveService : IMongoSaveService
    {
        private readonly IMongoClient _mongoClient;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="MongoDbSaveService"/>.
        /// </summary>
        /// <param name="mongoClient">MongoDB клиент.</param>
        public MongoDbSaveService(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        /// <summary>
        /// Асинхронно сохраняет коллекцию данных в указанную базу данных MongoDB.
        /// </summary>
        /// <typeparam name="T">Тип данных для сохранения.</typeparam>
        /// <param name="items">Коллекция данных для сохранения.</param>
        /// <param name="databaseName">Имя базы данных.</param>
        /// <returns>Задача, представляющая асинхронный процесс сохранения данных.</returns>
        public async Task SaveAsync<T>(IEnumerable<T> items, string databaseName)
        {
            IMongoDatabase database = _mongoClient.GetDatabase(databaseName);
            IMongoCollection<T> collection = database.GetCollection<T>(typeof(T).Name);

            await collection.InsertManyAsync(items);
        }
    }
}
