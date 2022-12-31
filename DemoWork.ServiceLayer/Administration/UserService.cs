using DemoWork.DataLayer.DataLayer;
using DemoWork.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoWork.ServiceLayer.Administration
{
    public class UserService
    {
        private readonly UserDataLayer _userDataLayer;
        public UserService()
        {
            _userDataLayer = new UserDataLayer();
        }

        public async Task<List<User>> GetUsers()
        {
            //var owners = await _context.Owners.ToListAsync();
            var user = await _userDataLayer.GetAll();

            return user;
        }
    }
}
