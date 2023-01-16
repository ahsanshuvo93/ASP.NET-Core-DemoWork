using DemoWork.DataLayer.BaseRepository;
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
        //private DemoWorkContext _demoWorkContext;

        //public CustomerDataLayer()
        //{
        //    _demoWorkContext = new DemoWorkContext();
        //}


        private IUnitOfWork uow;
        private DemoWorkContext _demoWorkContext;

        public CustomerDataLayer()
        {
            uow = new UnitOfWork();
            _demoWorkContext = new DemoWorkContext();
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            try
            {
                var customers = await uow.CustomerRepository.GetAllAsync();
                return customers;
            }
            catch (Exception ex)
            {

                return null;
            }            
        }

        public async Task<IEnumerable<Customer>> GetActive()
        {
            try
            {
                var customers = await uow.CustomerRepository.GetManyAsync(
                                    filter: s => s.Status == "Active",
                                    orderBy: s => s.OrderBy(s => s.FullName),
                                    top: 5,
                                    skip: 0,
                                    includeProperties: "CustomerLogs"
                                );

                var cus = await uow.CustomerRepository.GetAll().Where(s=>s.Status == "Active").Include(s=>s.CustomerLogs).ToListAsync();

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
                var customer = await uow.CustomerRepository.FindAsync(customerId);

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

                await uow.CustomerRepository.AddAsync(customer);

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
                var result = await uow.CustomerRepository.FindAsync(customer.CustomerId);

                result.FullName = customer.FullName;
                result.Email = customer.Email;
                result.PhoneNumber = customer.PhoneNumber;
                result.DateOfBirth = customer.DateOfBirth;
                result.Address = customer.Address;
                result.Password = customer.Password;
                result.Status = customer.Status;

                await uow.CustomerRepository.EditAsync(result);

                return customer;
            }
            catch (Exception ex)
            {

                return null;
            }            
        }
    }
}
