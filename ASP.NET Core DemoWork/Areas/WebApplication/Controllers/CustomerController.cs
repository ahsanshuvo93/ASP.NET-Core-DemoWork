using DemoWork.ServiceLayer.WebAPIs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_DemoWork.Areas.WebApplication.Controllers
{
    [Area("WebApplication")]
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerService;

        public CustomerController()
        {
            _customerService = new CustomerService();
        }

        public async Task<IActionResult> Index()
        {
            
            var model = await _customerService.GetAllCustomers();
            return View();
        }
    }
}
