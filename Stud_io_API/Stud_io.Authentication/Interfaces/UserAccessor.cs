using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Stud_io.Authentication.Interfaces
{
    public class UserAccessor : IUserAccessor
    {
        private IHttpContextAccessor _httpContextAccesor;
        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccesor = httpContextAccessor;
        }

        public string GetUsername()
        {
            return _httpContextAccesor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }
    }
}