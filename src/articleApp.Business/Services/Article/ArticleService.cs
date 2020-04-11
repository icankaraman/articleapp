using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using articleApp.Business.Extensions;
using articleApp.Business.Repository;
using articleApp.Data.Enum;
using articleApp.Data.Models;
using articleApp.Data.OtherModels;
using AutoMapper;
using MongoDB.Bson;

namespace articleApp.Business.Services
{
    public class ArticleService : IArticleService
    {
        private IRepository<Article> _articleRepo;
        private ICategoryService _categoryService;
        private IUserService _userService;
        private readonly IMapper _mapper;

        public ArticleService(IRepository<Article> articleRepo,
           ICategoryService categoryService,
           IUserService userService,
           IMapper mapper
        )
        {
            _articleRepo = articleRepo;
            _categoryService = categoryService;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<Article> GetArticleById(string id)
        {
            try
            {
                var list = await _articleRepo.GetList(c => c.Id == id && c.Status == (byte)StatusType.Active);
                if (list.Count != 1)
                    throw new NotificationException("Makale Bulunamadı.");

                return list.First();
            }
            catch (System.Exception ex)
            {
                throw new NotificationException(ex.Message);
            }
        }

        public async Task<bool> ValidationArticle(ArticleRequestModel model)
        {
            var customer = await _userService.GetUserById(model.UserId);
            if (customer == null)
            {
                throw new NotificationException("Kullanıcı bilgisi bulunamadı.");
            }
            else if (customer.UserType == (byte)UserType.Reader)
                throw new NotificationException("Yazar olmayan kullanıcı makale girdisi yapamaz.");

            var category = await _categoryService.GetCategoryById(model.CategoryId);
            if (customer == null)
            {
                throw new NotificationException("Kategori bilgisi bulunamadı.");
            }
            return true;
        }

        public async Task<Article> CreateArticle(ArticleRequestModel model)
        {
            var article = new Article();

            await ValidationArticle(model);

            article.Id = ObjectId.GenerateNewId().ToString();
            article.UserId = model.UserId;
            article.CreateDate = DateTime.Now;
            article.Status = (byte)StatusType.Active;

            article.Description = model.Description;
            article.CategoryId = model.CategoryId;
            article.MainTitle = model.MainTitle;
            article.Title = model.Title;

            await Insert(article);

            return article;
        }

        public async Task<Article> UpdateArticle(string id, ArticleRequestModel model)
        {
            var article = await GetArticleById(id);

            await ValidationArticle(model);

            article.UserId = model.UserId;
            article.UpdateDate = DateTime.Now;
            article.Status = (byte)StatusType.Active;

            article.Description = model.Description;
            article.CategoryId = model.CategoryId;
            article.MainTitle = model.MainTitle;
            article.Title = model.Title;

            await Update(article);
            return article;
        }

        public async Task<Article> Insert(Article model)
        {
            try
            {
                var entity = await _articleRepo.Create(model);
                return entity;
            }
            catch (System.Exception ex)
            {

                throw new NotificationException(ex.Message);
            }
        }
        public async Task<Article> Update(Article model)
        {
            try
            {
                var entity = await _articleRepo.Update(model.Id, model);
                return entity;
            }
            catch (System.Exception ex)
            {

                throw new NotificationException(ex.Message);
            }
        }
        public async Task<bool> Delete(Article model)
        {
            try
            {
                var result = await _articleRepo.Delete(model);
                return result;
            }
            catch (System.Exception ex)
            {
                throw new NotificationException(ex.Message);
            }
        }

        public async Task<List<Article>> SeedArticleData()
        {
            var articleList = new List<Article>(){
                new Article()
                {
                    CategoryId ="5e920e860deb933d800d06fe",
                    UserId = "5e920e860deb933d800d04fe",
                    MainTitle = "Teknoloji Son Dakika",
                    Title="Teknolojide Büyük Gelisme",
                    Description="Lorem ipsum dolor",
                    CreateDate = DateTime.UtcNow,
                    Status=(byte)StatusType.Active,
                },
                new Article()
                {
                    CategoryId ="5e920e860deb933d800d07fe",
                    UserId = "5e920e860deb933d800d04fe",
                    MainTitle = "Bilim Son Dakika",
                    Title="Bilimde Büyük Gelisme",
                    Description="Lorem ipsum dolor",
                    CreateDate = DateTime.UtcNow,
                    Status=(byte)StatusType.Active,
                }
            };
            await _articleRepo.InsertList(articleList);
            return articleList;
        }
    }
}