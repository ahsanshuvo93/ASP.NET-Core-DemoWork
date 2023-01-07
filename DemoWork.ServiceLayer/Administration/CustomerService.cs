using DemoWork.DataLayer.DataLayer;
using DemoWork.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoWork.ServiceLayer.Administration
{
    public class CustomerService
    {
        private readonly CustomerDataLayer _customerDataLayer;
        public CustomerService()
        {
            _customerDataLayer = new CustomerDataLayer();
        }

        public async Task<List<Customer>> GetCustomers()
        {
            //var owners = await _context.Owners.ToListAsync();
            var customer = await _customerDataLayer.GetAll();

            return customer;
        }
    }
}
