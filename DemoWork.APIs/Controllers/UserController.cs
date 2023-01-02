using DemoWork.DataLayer.DataLayer;
using DemoWork.Entities.Models;
using DemoWork.ServiceLayer.WebAPIs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWork.APIs.Controllers
{
    [Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        
        [HttpGet]
        [Route("GetUserById")]
        public async Task<ActionResult<User>> GetUserById(Guid userId)
        {
            var users = await _userService.GetById(userId);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        [HttpPost]
        [Route("AddUsers")]
        public async Task<ActionResult<User>> AddUsers(User user)
        {
            var users = await _userService.AddUsers(user);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        [HttpPost]
        [Route("EditUsers")]
        public async Task<ActionResult<User>> EditUsers(User user)
        {
            var users = await _userService.EditUsers(user);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }
    }
}
