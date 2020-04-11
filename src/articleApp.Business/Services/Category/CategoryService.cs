using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using articleApp.Business.Extensions;
using articleApp.Business.Repository;
using articleApp.Data.Enum;
using articleApp.Data.Models;
using MongoDB.Bson;

namespace articleApp.Business.Services
{
    public class CategoryService : ICategoryService
    {
        public IRepository<Category> _categoryRepo;
        public CategoryService(IRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task<Category> GetCategoryById(string id)
        {
            try
            {
                var entity = await _categoryRepo.Find(c => c.Id == id && c.Status == (byte)StatusType.Active);
                return entity;
            }
            catch (System.Exception ex)
            {
                throw new NotificationException(ex.Message);
            }
        }

        public async Task<Category> Insert(Category model)
        {
            try
            {
                var entity = await _categoryRepo.Create(model);
                return entity;
            }
            catch (System.Exception ex)
            {

                throw new NotificationException(ex.Message);
            }
        }

        public async Task<Category> Update(Category model)
        {
            try
            {
                var entity = await _categoryRepo.Update(model.Id, model);
                return entity;
            }
            catch (System.Exception ex)
            {

                throw new NotificationException(ex.Message);
            }
        }
        public async Task<bool> Delete(Category model)
        {
            try
            {
                var isDeleted = await _categoryRepo.Delete(model);
                return isDeleted;
            }
            catch (System.Exception ex)
            {

                throw new NotificationException(ex.Message);
            }
        }
        public async Task<List<Category>> SeedCategoryData()
        {
            var categoryList = new List<Category>(){
                new Category()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Teknoloji",
                    Description="Teknolojiye Dair Makaleler",
                    CreateDate = DateTime.UtcNow,
                    Status=(byte)StatusType.Active,
                },
                new Category()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Bilim",
                    Description="Bilime Dair Makaleler",
                    CreateDate = DateTime.UtcNow,
                    Status=(byte)StatusType.Active,
                },
                 new Category()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Bonny Food",
                    Description = "Sağlığa Dair Makaleler",
                    CreateDate = DateTime.UtcNow,
                    Status=(byte)StatusType.Active,
                }
            };
            await _categoryRepo.InsertList(categoryList);
            return categoryList;
        }
    }
}