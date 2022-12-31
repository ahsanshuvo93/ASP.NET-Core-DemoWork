using DemoWork.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoWork.Entities
{
    public class DemoWorkContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-NPF57F5;Database=DemoWork;User Id=sa;Password=123456;MultipleActiveResultSets=true");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }

    }
}
