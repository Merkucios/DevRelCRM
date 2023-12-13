using AngleSharp;
using AngleSharp.Dom;
using DevRelCRM.Infrastructure.Parsers.Habr.Models;

namespace DevRelCRM.Infrastructure.Parsers.Habr
{
    public static class HabrParser
    {
        /// <summary>
        /// Асинхронный метод для парсинга статей по заданному URL.
        /// </summary>
        /// <param name="url">URL страницы со статьями.</param>
        /// <returns>Коллекция объектов HabrArticle.</returns>
        public static async Task<IEnumerable<HabrArticle>> ParseArticlesAsync()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            var document = await context.OpenAsync(HabrConstants.ARTICLES_URL);

            var lastPage = GetLastPage(document);
            if (lastPage.HasValue)
            {
                List<HabrArticle> articles = new List<HabrArticle>();

                for (int currentPage = 1; currentPage <= lastPage.Value; currentPage++)
                {
                    var currentUrl = $"{HabrConstants.ARTICLES_URL}page{currentPage}/";
                    var currentDocument = await context.OpenAsync(currentUrl);

                    var articleElements = currentDocument.QuerySelectorAll(".tm-articles-list__item");
                    articles.AddRange(ProcessArticleElements(articleElements));
                }
                return articles;
            }
            else
            {
                Console.WriteLine("Не удалось найти блок tm-pagination__page-group.");
                return Enumerable.Empty<HabrArticle>();
            }
        }

        public static async Task<IEnumerable<HabrNews>> ParseNewsAsync(int? countPages = null)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            int? lastPage;
            var document = await context.OpenAsync(HabrConstants.NEWS_URL);

            if (countPages.HasValue && countPages.Value <= GetLastPage(document))
            {
                lastPage = countPages;
            }
            else
            {
                lastPage = GetLastPage(document);
            }
            if (lastPage.HasValue)
            {
                List<HabrNews> news = new List<HabrNews>();

                for (int currentPage = 1; currentPage <= lastPage.Value; currentPage++)
                {
                    var currentUrl = $"{HabrConstants.NEWS_URL}page{currentPage}/";
                    var currentDocument = await context.OpenAsync(currentUrl);

                    var newsElements = currentDocument.QuerySelectorAll(".tm-articles-list__item");
                    news.AddRange(ProcessNewsElements(newsElements));
                }
                return news;
            }
            else
            {
                Console.WriteLine("Не удалось найти блок tm-pagination__page-group.");
                return Enumerable.Empty<HabrNews>();
            }
        }

        /// <summary>
        /// Получение номера последней страницы.
        /// </summary>
        /// <param name="document">Документ страницы.</param>
        /// <returns>Номер последней страницы.</returns>
        private static int? GetLastPage(IDocument document)
        {
            var lastPageGroup = document.QuerySelectorAll(".tm-pagination__page-group").LastOrDefault();

            if (lastPageGroup != null)
            {
                var lastPageElement = lastPageGroup.QuerySelector(".tm-pagination__page");

                if (lastPageElement != null && int.TryParse(lastPageElement.TextContent.Trim(), out int lastPage))
                {
                    return lastPage;
                }
                else
                {
                    Console.WriteLine("Не удалось получить номер последней страницы.");
                }
            }
            else
            {
                Console.WriteLine("Не удалось найти блок tm-pagination__page-group.");
            }

            return null;
        }

        /// <summary>
        /// Обработка элементов статьи и создание объектов HabrArticle.
        /// </summary>
        /// <param name="articleElements">Коллекция элементов статей.</param>
        /// <returns>Коллекция объектов HabrArticle.</returns>
        private static IEnumerable<HabrArticle> ProcessArticleElements(IHtmlCollection<IElement> articleElements)
        {
            foreach (var articleElement in articleElements)
            {
                var link = GetArticleLink(articleElement);
                var spanContent = GetArticleTitle(articleElement);
                var complexity = GetArticleComplexity(articleElement);
                var readingTime = GetArticleReadingTime(articleElement);
                var categories = GetArticleCategories(articleElement);
                var rating = GetArticleRating(articleElement);

                Console.WriteLine($"Ссылка: {link}");
                Console.WriteLine($"Заголовок: {spanContent}");
                Console.WriteLine($"Сложность чтения: {complexity}");
                Console.WriteLine($"Время чтения: {readingTime}");
                Console.WriteLine($"Категории: {string.Join(", ", categories)}");
                Console.WriteLine($"Рейтинг: {rating}");
                Console.WriteLine();

                yield return new HabrArticle
                {
                    Link = link,
                    Title = spanContent,
                    Complexity = complexity,
                    ReadingTime = readingTime,
                    Categories = categories,
                    Rating = rating
                };
            }
        }

        /// <summary>
        /// Обработка элементов статьи и создание объектов HabrArticle.
        /// </summary>
        /// <param name="articleElements">Коллекция элементов статей.</param>
        /// <returns>Коллекция объектов HabrArticle.</returns>
        private static IEnumerable<HabrNews> ProcessNewsElements(IHtmlCollection<IElement> articleElements)
        {
            foreach (var articleElement in articleElements)
            {
                var link = GetArticleLink(articleElement);
                var spanContent = GetArticleTitle(articleElement);
                var readingTime = GetArticleReadingTime(articleElement);
                var categories = GetArticleCategories(articleElement);
                var rating = GetArticleRating(articleElement);

                Console.WriteLine($"Ссылка: {link}");
                Console.WriteLine($"Заголовок: {spanContent}");
                Console.WriteLine($"Время чтения: {readingTime}");
                Console.WriteLine($"Категории: {string.Join(", ", categories)}");
                Console.WriteLine($"Рейтинг: {rating}");
                Console.WriteLine();

                yield return new HabrNews
                {
                    Link = link,
                    Title = spanContent,
                    ReadingTime = readingTime,
                    Categories = categories,
                    Rating = rating
                };
            }
        }

        private static string GetArticleLink(IElement articleElement)
        {
            var titleElement = articleElement.QuerySelector(".tm-title.tm-title_h2 .tm-title__link span");
            var linkElement = titleElement?.ParentElement;
            return linkElement != null ? HabrConstants.BASE_URL + linkElement.GetAttribute("href") : string.Empty;
        }

        private static string GetArticleTitle(IElement articleElement)
        {
            var titleElement = articleElement.QuerySelector(".tm-title.tm-title_h2 .tm-title__link span");
            return titleElement?.TextContent.Trim() ?? string.Empty;
        }

        private static string GetArticleComplexity(IElement articleElement)
        {
            var complexityElement = articleElement.QuerySelector(".tm-article-complexity__label");
            return complexityElement?.TextContent.Trim() ?? string.Empty;
        }

        private static string GetArticleReadingTime(IElement articleElement)
        {
            var readingTimeElement = articleElement.QuerySelector(".tm-article-reading-time__label");
            return readingTimeElement?.TextContent.Trim() ?? string.Empty;
        }

        private static IEnumerable<string> GetArticleCategories(IElement articleElement)
        {
            var categoryElements = articleElement.QuerySelectorAll(".tm-publication-hubs .tm-publication-hub__link span");
            return categoryElements
                .Select(c => c.TextContent.Trim())
                .Where(c => c != "*");
        }

        private static string GetArticleRating(IElement articleElement)
        {
            var ratingElement = articleElement.QuerySelector(".tm-votes-meter__value.tm-votes-meter__value_rating");
            return ratingElement?.TextContent.Trim() ?? string.Empty;
        }

    }
}
