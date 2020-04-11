using System.Collections.Generic;
using System.Threading.Tasks;
using articleApp.Data.Models;
using articleApp.Data.OtherModels;

namespace articleApp.Business.Services
{
    public interface IArticleService
    {
        Task<Article> Insert(Article model);
        Task<Article> Update(Article model);
        Task<bool> Delete(Article model);
        Task<Article> CreateArticle(ArticleRequestModel model);
        Task<Article> UpdateArticle(string id, ArticleRequestModel model);
        Task<Article> GetArticleById(string id);
        Task<List<Article>> SeedArticleData();
    }
}