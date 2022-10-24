using Application.DataTransferObject;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;   
        }

        [HttpPost("/article")]
        public async Task<IActionResult> AddArticle([FromBody] ArticleDto articleDto)
        {
            var result = await _articleService.saveArticle(articleDto);
            if (!result)
            {
                return BadRequest();
            }
            else
            {
                return Ok(true);
            }
        }


        [HttpGet("/article/{id}")]
        public async Task<IActionResult> GetArticleListById(int id)
        {
            var result = await _articleService.getArticleListById(id);
            return Ok(result);
        }
    }
}
