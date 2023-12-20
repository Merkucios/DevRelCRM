namespace DevRelCRM.Infrastructure.Parsers.Habr.Models
{
    /// <summary>
    /// Класс, представляющий информацию о статье на Хабре.
    /// </summary>
    public class HabrArticle
    {
        public string Link { get; set; }
        public string Title { get; set; }
        public string Complexity { get; set; }
        public string ReadingTime { get; set; }
        public IEnumerable<string>? Categories { get; set; }
        public string Rating { get; set; }
    }
}
