using DemoWork.DataLayer.DataLayer;
using DemoWork.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoWork.ServiceLayer.WebAPIs
{
    public class CustomerService
    {
        private readonly CustomerDataLayer _customerDataLayer;
        public CustomerService()
        {
            _customerDataLayer = new CustomerDataLayer();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customer = await _customerDataLayer.GetActive();
            return customer;
        }

        public async Task<Customer> GetById(Guid customerId)
        {
            var customer = await _customerDataLayer.GetById(customerId);
            return customer;
        }

        public async Task<Customer> AddCustomers(Customer customer)
        {
            customer = await _customerDataLayer.Add(customer);
            return customer;
        }

        public async Task<Customer> EditCustomers(Customer customer)
        {
            customer = await _customerDataLayer.Edit(customer);
            return customer;
        }
    }
}
