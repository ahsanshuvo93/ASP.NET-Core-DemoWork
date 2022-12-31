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
    public class UserDataLayer
    {
        private DemoWorkContext _demoWorkContext;

        public UserDataLayer()
        {
            _demoWorkContext = new DemoWorkContext();
        }

        public async Task<List<User>> GetAll()
        {
            try
            {
                var users = await _demoWorkContext.Users.ToListAsync();
                return users;
            }
            catch (Exception ex)
            {

                return null;
            }            
        }

        public async Task<List<User>> GetActive()
        {
            try
            {
                var users = await _demoWorkContext.Users.Where(s => s.Status == "Active").ToListAsync();
                return users;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<User> GetById(Guid UserId)
        {
            try
            {
                var users = await _demoWorkContext.Users.FindAsync(UserId);
                return users;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<User> Add(User user)
        {
            try
            {
                user.CreatedAt = DateTime.Now;
                user.Status = "Active";

                await _demoWorkContext.Users.AddAsync(user);
                await _demoWorkContext.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {

                return null;
            }            
        }

        public async Task<User> Edit(User user)
        {
            try
            {
                var result = await _demoWorkContext.Users.FindAsync(user.UserId);

                result.Name = user.Name;
                result.DateOfBirth = user.DateOfBirth;
                result.Address = user.Address;
                result.Password = user.Password;
                result.Status = user.Status;

                _demoWorkContext.Entry(result).State = EntityState.Modified;
                await _demoWorkContext.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {

                return null;
            }            
        }
    }
}
