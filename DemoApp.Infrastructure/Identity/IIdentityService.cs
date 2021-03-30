using DemoApp.Infrastructure.Identity.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Infrastructure.Identity
{
    public interface IIdentityService
    {
        Task<LoginResponseDto> Login(UserLoginDto user);
    }
}
