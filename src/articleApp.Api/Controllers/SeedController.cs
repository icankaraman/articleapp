using System.Collections;
using System.Threading.Tasks;
using articleApp.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace articleApp.Api.Controllers
{
    [Route("seed")]
    [ApiController]
    public class SeedController : Controller
    {
        public ICategoryService _categoryService;
        public IUserService _userService;
        public IArticleService _articleService;

        public SeedController(ICategoryService categoryService,
        IUserService userService,
        IArticleService articleService
        )
        {
            _categoryService = categoryService;
            _userService = userService;
            _articleService = articleService;
        }

        [HttpPost]
        public async Task<IActionResult> SeedData()
        {
            ArrayList arrayList = new ArrayList();
            try
            {
                var userList = await _userService.SeedUserData();
                var categoryList = await _categoryService.SeedCategoryData();
                var articleList = await _articleService.SeedArticleData();
                arrayList.Add(userList);
                arrayList.Add(categoryList);
                arrayList.Add(articleList);
            }
            catch (System.Exception)
            {
                return UnprocessableEntity("Veri yüklemede Hata oluştu.");
            }
            return Ok(arrayList);
        }
    }
}