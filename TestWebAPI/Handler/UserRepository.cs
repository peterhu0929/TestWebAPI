using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAPI.Models;

namespace TestWebAPI.Handler
{
    public class UserRepository:IUserRepository
    {
        private readonly DataAccess _db;
        public UserRepository(DataAccess db)
        {
            _db = db;
        }
        public Response<User> AddUser(User u)
        {
            var result = new Response<User>();
            result.IsSuccess = true;
            try
            {
                result.Data = _db.CreateUser(u);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public Response<bool> DeleteUser(string Id)
        {
            var result = new Response<bool>();
            result.IsSuccess = true;
            try
            {
                var objId = new ObjectId(Id);
                result.Data = _db.RemoveUser(objId);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public Response<IEnumerable<User>> GetAllUser()
        {
            var result = new Response<IEnumerable<User>>();
            result.IsSuccess = true;
            try
            {
                result.Data = _db.GetUsers();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public Response<User> GetUserById(string Id)
        {
            var result = new Response<User>();
            result.IsSuccess = true;
            try
            {
                var objId = new ObjectId(Id);
                result.Data = _db.GetUser(objId);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public Response<bool> UpdateUser(string Id, User u)
        {
            var result = new Response<bool>();
            result.IsSuccess = true;
            try
            {
                var objId = new ObjectId(Id);
                result.Data = _db.UpdateUser(objId, u);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
