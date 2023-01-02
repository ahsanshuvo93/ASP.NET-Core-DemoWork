using DemoWork.Entities.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace DemoWork.Common.Common
{
    public class AuthenticateService : IAuthenticateService
    {
        private static Guid S_AuthenticationId { get; set; } = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709");
        private static string S_FullName { get; set; } = "Ahsan Shuvo";
        private static string S_UserName { get; set; } = "ahsan";
        private static string S_Password { get; set; } = "shuvo";
        private static string S_Role { get; set; } = "Admin";

        private readonly AppSettings _appSetinigs;

        // Inject AppSeting in Controller
        public AuthenticateService(IOptions<AppSettings> appSettings)
        {
            _appSetinigs = appSettings.Value;
        }

        private List<Authentication> authenticationList = new List<Authentication>()
        {
            new Authentication { AuthenticationId = S_AuthenticationId, FullName = S_FullName, UserName = S_UserName, Password = S_Password, Role = S_Role }
        };

        public Authentication Authenticate(string _userName, string _password)
        {
            var response = authenticationList.SingleOrDefault(s => s.UserName == _userName && s.Password == _password);

            if (response == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetinigs.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Sid, response.AuthenticationId.ToString()),
                    new Claim(ClaimTypes.Name, response.UserName.ToString()),
                    new Claim(ClaimTypes.Role, response.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            response.Token = tokenHandler.WriteToken(token);

            response.Password = null;

            return response;
        }

       
    }
}
