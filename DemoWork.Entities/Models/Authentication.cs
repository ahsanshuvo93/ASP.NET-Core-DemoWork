using System;
using System.Collections.Generic;
using System.Text;

namespace DemoWork.Entities.Models
{
    public class Authentication
    {
        public Guid AuthenticationId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
