using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Application.Interface
{
    public interface IUserManager
    { string GenerateToken(Domain.Models.User user, string tokenKey);
        int GetUserId();
        UserType GetUserType();
        string GetUserName();
        Guid GetRequestId();
        ClaimsPrincipal GetUser();
    }
}
