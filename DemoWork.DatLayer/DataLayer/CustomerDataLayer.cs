using DemoWork.Entities;
using DemoWork.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWork.DataLayer.DataLayer
{
    public class CustomerDataLayer
    {
        private DemoWorkContext _demoWorkContext;

        public CustomerDataLayer()
        {
            _demoWorkContext = new DemoWorkContext();
        }

        public async Task<List<Customer>> GetAll()
        {
            try
            {
                var customers = await _demoWorkContext.Customers.ToListAsync();
                return customers;
            }
            catch (Exception ex)
            {

                return null;
            }            
        }

        public async Task<List<Customer>> GetActive()
        {
            try
            {
                var customers = await _demoWorkContext.Customers.Where(s => s.Status == "Active").ToListAsync();
                return customers;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<Customer> GetById(Guid customerId)
        {
            try
            {
                var customer = await _demoWorkContext.Customers.FindAsync(customerId);
                return customer;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<Customer> Add(Customer customer)
        {
            try
            {
                customer.CreatedAt = DateTime.Now;
                customer.Status = "Active";

                await _demoWorkContext.Customers.AddAsync(customer);
                await _demoWorkContext.SaveChangesAsync();

                return customer;
            }
            catch (Exception ex)
            {

                return null;
            }            
        }

        public async Task<Customer> Edit(Customer customer)
        {
            try
            {
                var result = await _demoWorkContext.Customers.FindAsync(customer.CustomerId);

                result.FullName = customer.FullName;
                result.Email = customer.Email;
                result.PhoneNumber = customer.PhoneNumber;
                result.DateOfBirth = customer.DateOfBirth;
                result.Address = customer.Address;
                result.Password = customer.Password;
                result.Status = customer.Status;

                _demoWorkContext.Entry(result).State = EntityState.Modified;
                await _demoWorkContext.SaveChangesAsync();

                return customer;
            }
            catch (Exception ex)
            {

                return null;
            }            
        }
    }
}
