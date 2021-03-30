using DemoApp.Core;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DemoApp.Api
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Subject);
    }
}
