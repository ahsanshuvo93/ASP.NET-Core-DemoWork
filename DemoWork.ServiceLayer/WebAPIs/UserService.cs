using DemoWork.DataLayer.DataLayer;
using DemoWork.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoWork.ServiceLayer.WebAPIs
{
    public class UserService
    {
        private readonly UserDataLayer _userDataLayer;
        public UserService()
        {
            _userDataLayer = new UserDataLayer();
        }

        public async Task<List<User>> GetAllUsers()
        {
            var user = await _userDataLayer.GetActive();
            return user;
        }

        public async Task<User> GetById(Guid userId)
        {
            var user = await _userDataLayer.GetById(userId);
            return user;
        }

        public async Task<User> AddUsers(User user)
        {
            user = await _userDataLayer.Add(user);
            return user;
        }

        public async Task<User> EditUsers(User user)
        {
            user = await _userDataLayer.Edit(user);
            return user;
        }
    }
}
