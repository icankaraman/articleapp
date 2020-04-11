using System.Threading.Tasks;
using articleApp.Business.Services;
using articleApp.Data.OtherModels;
using Microsoft.AspNetCore.Mvc;

namespace articleApp.Api.Controllers
{
    [Route("article")]
    [ApiController]
    public class ArticleController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;
        private readonly IUserService _userService;

        public ArticleController(ICategoryService categoryService, IArticleService articleService, IUserService userService)
        {
            _categoryService = categoryService;
            _articleService = articleService;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var result = await _articleService.GetArticleById(id);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return UnprocessableEntity($"{"Hata Oluştu !" + ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] ArticleRequestModel model)
        {
            try
            {
                var result = await _articleService.CreateArticle(model);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return UnprocessableEntity($"{"Hata Oluştu !" + ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(string id, [FromBody] ArticleRequestModel model)
        {
            try
            {
                var result = await _articleService.UpdateArticle(id, model);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return UnprocessableEntity($"{"Hata Oluştu !" + ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(string id)
        {
            try
            {
                var result = await _articleService.GetArticleById(id);
                var response = await _articleService.Delete(result);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return UnprocessableEntity($"{"Hata Oluştu !" + ex.Message}");
            }

        }
    }
}
