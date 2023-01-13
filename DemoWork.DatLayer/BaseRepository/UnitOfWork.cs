using DemoWork.Entities;
using DemoWork.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoWork.DataLayer.BaseRepository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public DemoWorkContext _dbContext;

        public UnitOfWork()
        {
            _dbContext = new DemoWorkContext();
        }

        //public UnitOfWork()
        //{
        //}


        #region Customer

        private GenericRepository<Customer> customerRepository;

        public IGenericRepository<Customer> CustomerRepository
        {
            get
            {
                if (customerRepository == null)
                    this.customerRepository = new GenericRepository<Customer>(_dbContext);
                return customerRepository;
            }
        }

        #endregion

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
