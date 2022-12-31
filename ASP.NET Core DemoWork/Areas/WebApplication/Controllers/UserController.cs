using DemoWork.ServiceLayer.WebAPIs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_DemoWork.Areas.WebApplication.Controllers
{
    [Area("WebApplication")]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        public async Task<IActionResult> Index()
        {
            
            var model = await _userService.GetAllUsers();
            return View();
        }
    }
}
