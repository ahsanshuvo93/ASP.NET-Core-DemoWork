using System;
using System.Collections.Generic;
using System.Text;
using DemoWork.Entities.Models;


namespace DemoWork.Common.Common
{
    public interface IAuthenticateService
    {
        Authentication Authenticate(string UserName, string Password);
    }
}
