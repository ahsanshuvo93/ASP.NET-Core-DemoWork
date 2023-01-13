using DemoWork.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoWork.DataLayer.BaseRepository
{
    public interface IUnitOfWork
    {
        IGenericRepository<Customer> CustomerRepository { get; }
    }
}
