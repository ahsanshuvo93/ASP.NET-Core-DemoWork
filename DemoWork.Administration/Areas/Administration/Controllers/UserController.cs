using DemoWork.ServiceLayer.Administration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWork.Administration.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        public async Task<IActionResult> Index()
        {
            var model = await _userService.GetUsers();
            return View();
        }
    }
}
