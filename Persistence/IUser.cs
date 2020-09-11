using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IUser
    {
        Task<User> AuthenticateUser(string userName, string password);
        Task<int> RegisterUser(User user);

    }
}
