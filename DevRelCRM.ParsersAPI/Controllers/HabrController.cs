using DevRelCRM.Infrastructure.Database.MongoDB;
using DevRelCRM.Infrastructure.Database.MongoDB.Habr.Services;
using DevRelCRM.Infrastructure.Database.MongoDB.Habr;
using DevRelCRM.Infrastructure.Parsers.Habr;
using DevRelCRM.Infrastructure.Parsers.Habr.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevRelCRM.ParsersAPI.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class HabrController : Controller
    {
        private readonly IMongoSaveService _mongoSaveService;

        public HabrController(IMongoSaveService mongoSaveService)
        {
            _mongoSaveService = mongoSaveService ?? throw new ArgumentNullException(nameof(mongoSaveService));
        }


        [HttpPost("parse-articles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ParseArticles()
        {
            try
            {
                IEnumerable<HabrArticle> articles = await HabrParser.ParseArticlesAsync();

                await _mongoSaveService.SaveAsync(articles, MongoDbNames.HABR_DATABASE);

                return Ok("Статьи успешно спаршены и сохранены в Mongo.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Произошла ошибка сервера. Даннные не отправлены. { ex.Message}");
            }
        }

        [HttpPost("parse-news")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ParseNews(int? endPage = null)
        {
            try
            {
                IEnumerable<HabrNews> news = await HabrParser.ParseNewsAsync();

                await _mongoSaveService.SaveAsync(news, MongoDbNames.HABR_DATABASE);

                return Ok("Новости успешно спаршены и сохранены в Mongo.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Произошла ошибка сервера. Даннные не отправлены. {ex.Message}");
            }
        }
    }
}
