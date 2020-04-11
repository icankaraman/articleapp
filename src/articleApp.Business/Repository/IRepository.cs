using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using articleApp.Data.Models;

namespace articleApp.Business.Repository
{
    public interface IRepository<TModel> where TModel : MainModel
    {
        Task<TModel> GetById(string id);
        Task<List<TModel>> InsertList(List<TModel> modelList);
        Task<TModel> Create(TModel model);
        Task<TModel> Update(string id, TModel model);
        Task<bool> Delete(TModel model);
        Task<bool> Delete(string id);
        Task<bool> DeleteList(List<TModel> modelList);
        Task<TModel> Find(Expression<Func<TModel, bool>> predicate);
        Task<List<TModel>> GetList(Expression<Func<TModel, bool>> predicate);
    }
}