using DemoApp.Infrastructure.Identity.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
 
        private readonly JwtHandler _jwtHandler;

        public IdentityService(UserManager<IdentityUser> userManager, JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }

        public async Task<LoginResponseDto> Login(UserLoginDto userDto)
        {
            var user = await _userManager.FindByEmailAsync(userDto.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, userDto.Password))
                return new LoginResponseDto { IsAuthSuccessful = false, Token = null };

            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = await _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new LoginResponseDto { IsAuthSuccessful = true, Token = token };
        }
    }
}
