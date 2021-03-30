using DemoApp.Infrastructure.Identity;
using DemoApp.Infrastructure.Identity.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController: ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AccountController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var result = await _identityService.Login(userLoginDto);

            if (result.IsAuthSuccessful)
            {
                return Ok(result);
            }

            return Unauthorized(new LoginResponseDto { ErrorMessage = "Invalid Authentication" });
        }
    }
}
