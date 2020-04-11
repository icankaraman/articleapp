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
    public class UserService : IUserService
    {

        private readonly IRepository<User> _userRepo;
        public UserService(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> GetUserById(string id)
        {
            try
            {
                var entity = await _userRepo.Find(c => c.Id == id && c.Status == (byte)StatusType.Active);
                return entity;
            }
            catch (System.Exception ex)
            {
                throw new NotificationException(ex.Message);
            }
        }

        public async Task<User> Insert(User model)
        {
            try
            {
                var entity = await _userRepo.Create(model);
                return entity;
            }
            catch (System.Exception ex)
            {

                throw new NotificationException(ex.Message);
            }
        }

        public async Task<User> Update(User model)
        {
            try
            {
                var entity = await _userRepo.Update(model.Id, model);
                return entity;
            }
            catch (System.Exception ex)
            {

                throw new NotificationException(ex.Message);
            }
        }
        public async Task<bool> Delete(User model)
        {
            try
            {
                var isDeleted = await _userRepo.Delete(model);
                return isDeleted;
            }
            catch (System.Exception ex)
            {

                throw new NotificationException(ex.Message);
            }
        }

        public async Task<List<User>> SeedUserData()
        {
            var userList = new List<User>();
            userList.Add(new User()
            {
                Id = "5e920e860deb933d800d04fe",
                Name = "Can",
                Email = "cankaraman94@gmail.com",
                CreateDate = DateTime.Now,
                Status = (byte)StatusType.Active,
                UserType = (byte)UserType.Author,
            });
            userList.Add(new User()
            {
                Id = "5e920e860deb933d800d05fe",
                Name = "readerCan",
                Email = "readerCan@gmail.com",
                CreateDate = DateTime.Now,
                Status = (byte)StatusType.Active,
                UserType = (byte)UserType.Reader,
            });

            var modelList = await _userRepo.InsertList(userList);
            return modelList;
        }

        public async Task<bool> IsExistUser(string id)
        {
            var userModel = await _userRepo.GetById(id);
            if (userModel != null)
                return true;
            else
                return false;
        }
    }
}