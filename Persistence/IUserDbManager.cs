using Domain.Models;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IUserDbManager
    {
        Task<User> AuthenticateUser(string userName, string password);
        Task<int> RegisterUser(User user);

    }
}
