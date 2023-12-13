using DevRelCRM.Infrastructure.Database.MongoDB;
using DevRelCRM.Infrastructure.Parsers.Habr;
using DevRelCRM.Infrastructure.Parsers.Habr.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevRelCRM.ParsersAPI.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class HabrController : Controller
    {
        [HttpPost("parse-articles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ParseArticles()
        {
            Task<IEnumerable<HabrArticle>> articles = HabrParser.ParseArticlesAsync();
            JsonFileWriter.SaveToJson(await articles, "habr_articles");

            return Ok();
        }

        [HttpPost("parse-news")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ParseNews(int? endPage = null)
        {
            Task<IEnumerable<HabrNews>> news = HabrParser.ParseNewsAsync(endPage.Value);
            JsonFileWriter.SaveToJson(await news, "habr_news");

            return Ok();
        }
    }
}
