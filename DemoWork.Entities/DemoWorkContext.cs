﻿using DemoWork.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoWork.Entities
{
    public class DemoWorkContext : IdentityDbContext
    {

        //public DemoWorkContext(DbContextOptions<DemoWorkContext> options)
        //   : base(options)
        //{
        //}
        public DemoWorkContext(DbContextOptions<DemoWorkContext> options)
          : base(options)
        {
        }

        public DemoWorkContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-NPF57F5;Database=DemoWork;User Id=sa;Password=123456;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerLog> CustomerLogs { get; set; }

    }
}
