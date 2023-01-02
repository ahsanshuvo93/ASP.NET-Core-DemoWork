using DemoWork.Common.Common;
using DemoWork.Entities.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWork.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticateService;

        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        [Route("GetAuthentication")]
        public IActionResult GetAuthentication(Authentication model)
        {
            var response = _authenticateService.Authenticate(model.UserName, model.Password);
            //var response = new Authentication();

            if (response == null)
            {
                return BadRequest(new { message = "UserName or Password is Incorrect." });
            }

            return Ok(response);
        }
    }
}
