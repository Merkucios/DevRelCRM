using System.Text.Encodings.Web;
using System.Text.Json;

namespace DevRelCRM.Infrastructure.Database.MongoDB
{
    public class JsonFileWriter
    {
        /// <summary>
        /// Сохранение объектов IEnumerable<T> в формате JSON.
        /// </summary>
        /// <param name="items">Коллекция объектов T.</param>
        /// <param name="fileName">Имя файла для сохранения JSON.</param>
        public static void SaveToJson<T>(IEnumerable<T> items, string fileName)
        {
            // Получаем текущую директорию проекта
            string baseDir = Directory.GetCurrentDirectory();

            // Получаем директорию выше текущей (DevRelCRM)
            string topDir = Directory.GetParent(baseDir).ToString();
            string jsonFileStorage = Path.Combine(topDir, "JsonStorage/");

            // Если директории нет, то создаём её
            if (!Directory.Exists(jsonFileStorage))
            {
                Directory.CreateDirectory(jsonFileStorage);
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            var json = JsonSerializer.Serialize(items, options);
            File.WriteAllText(Path.Combine(jsonFileStorage, $"{fileName}.json"), json);
        }
    }
}
