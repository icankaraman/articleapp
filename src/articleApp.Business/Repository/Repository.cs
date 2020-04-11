using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using articleApp.Data.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace articleApp.Business.Repository
{
    public class Repository<TModel> : IRepository<TModel>
      where TModel : MainModel
    {
        protected readonly ArticleDbContext _context;
        protected readonly IMongoCollection<TModel> dataTable;

        public Repository(ArticleDbContext context)
        {
            _context = context;
            dataTable = _context.GetCollection<TModel>(typeof(TModel).Name);
        }

        public async virtual Task<TModel> GetById(string id)
        {
            TModel model = null;
            model = await dataTable.FindOneAndReplaceAsync<TModel>(m => m.Id == id, model);
            return model;
        }

        public async virtual Task<List<TModel>> InsertList(List<TModel> modelList)
        {
            await dataTable.InsertManyAsync(modelList);
            return modelList;
        }
        public async virtual Task<TModel> Create(TModel model)
        {
            await dataTable.InsertOneAsync(model);
            return model;
        }

        public async virtual Task<TModel> Update(string id, TModel model)
        {
            return await dataTable.FindOneAndReplaceAsync(m => m.Id == id, model);
        }


        public async virtual Task<bool> Delete(TModel model)
        {
            await dataTable.DeleteOneAsync(m => m.Id == model.Id);
            return true;
        }

        public async virtual Task<bool> DeleteList(List<TModel> modelList)
        {
            foreach (var item in modelList)
            {
                await dataTable.DeleteOneAsync(m => m.Id == item.Id);
            }
            return true;
        }

        public async virtual Task<bool> Delete(string id)
        {
            await dataTable.FindOneAndDeleteAsync(m => m.Id == id);
            return true;
        }

        public async virtual Task<TModel> Find(Expression<Func<TModel, bool>> predicate)
        {
            var query = dataTable.AsQueryable();
            return await query.Where(predicate).FirstOrDefaultAsync();
        }
        public async virtual Task<List<TModel>> GetList(Expression<Func<TModel, bool>> predicate)
        {
            var query = dataTable.AsQueryable();
            return await query.Where(predicate).ToListAsync();
        }
    }
}