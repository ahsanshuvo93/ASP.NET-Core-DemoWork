using DemoWork.ServiceLayer.Administration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWork.Administration.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerService;

        public CustomerController()
        {
            _customerService = new CustomerService();
        }

        public async Task<IActionResult> Index()
        {
            var model = await _customerService.GetCustomers();
            return View();
        }
    }
}
