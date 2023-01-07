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
    public class CustomerController : ControllerBase
    {

        private readonly CustomerService _customerService;

        public CustomerController()
        {
            _customerService = new CustomerService();
        }

        [HttpGet]
        [Route("GetCustomers")]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            var response = await _customerService.GetAllCustomers();

            if (response == null)
            {
                return NotFound();
            }

            return response;
        }

        
        [HttpGet]
        [Route("GetCustomerById")]
        public async Task<ActionResult<Customer>> GetCustomerById(Guid customerId)
        {
            var response = await _customerService.GetById(customerId);

            if (response == null)
            {
                return NotFound();
            }

            return response;
        }

        [HttpPost]
        [Route("AddCustomers")]
        public async Task<ActionResult<Customer>> AddCustomers(Customer Customer)
        {
            var response = await _customerService.AddCustomers(Customer);

            if (response == null)
            {
                return NotFound();
            }

            return response;
        }

        [HttpPost]
        [Route("EditCustomers")]
        public async Task<ActionResult<Customer>> EditCustomers(Customer Customer)
        {
            var response = await _customerService.EditCustomers(Customer);

            if (response == null)
            {
                return NotFound();
            }

            return response;
        }
    }
}
