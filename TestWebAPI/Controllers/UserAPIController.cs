using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Handler;
using TestWebAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestWebAPI.Controllers
{
    [Route("api/user/[action]/")]
    public class UserAPIController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserAPIController(IUserRepository repository)
        {
            _userRepository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public Response<IEnumerable<User>> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        // GET api/<controller>/5
        [HttpGet]
        public Response<User> GetUserById(string Id)
        {
            var response = _userRepository.GetUserById(Id);
            var s = response.Data.Id.ToString();
            return response;
        }

        // POST api/<controller>
        [HttpPost]
        public Response<User> AddUser([FromBody]User u)
        {
            var response = _userRepository.AddUser(u);
            return response;
        }

        [HttpPut]
        public Response<bool> UpdateUser(string Id, [FromBody] User u)
        {
            var response = _userRepository.UpdateUser(Id, u);
            return response;
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public Response<bool> DeleteUser(string Id)
        {
            var response = _userRepository.DeleteUser(Id);
            return response;
        }
    }
}
