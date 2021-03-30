using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoApp.Infrastructure.Identity.Dtos
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
