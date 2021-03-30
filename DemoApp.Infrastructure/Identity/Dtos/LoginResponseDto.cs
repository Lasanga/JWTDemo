using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Infrastructure.Identity.Dtos
{
    public class LoginResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}
