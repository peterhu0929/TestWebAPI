using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAPI.Models;

namespace TestWebAPI.Handler
{
    public interface IUserRepository
    {
        Response<IEnumerable<User>> GetAllUser();
        Response<User> GetUserById(string Id);
        Response<bool> DeleteUser(string Id);
        Response<User> AddUser(User u);
        Response<bool> UpdateUser(string Id, User u);
    }
}
