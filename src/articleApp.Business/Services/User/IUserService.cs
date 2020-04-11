using System.Collections.Generic;
using System.Threading.Tasks;
using articleApp.Data.Models;

namespace articleApp.Business.Services
{
    public interface IUserService
    {
        Task<bool> IsExistUser(string id);
        Task<List<User>> SeedUserData();
        Task<User> GetUserById(string id);
        Task<User> Insert(User model);
        Task<User> Update(User model);
        Task<bool> Delete(User model);
    }
}