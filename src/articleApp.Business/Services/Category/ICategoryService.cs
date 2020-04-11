using System.Collections.Generic;
using System.Threading.Tasks;
using articleApp.Data.Models;

namespace articleApp.Business.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> SeedCategoryData();
        Task<Category> GetCategoryById(string id);
        Task<Category> Insert(Category model);
        Task<Category> Update(Category model);
        Task<bool> Delete(Category model);
    }
}