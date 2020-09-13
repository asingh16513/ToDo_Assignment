using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Threading.Tasks;

namespace Database
{
    public class UserDbManager : IUserDbManager
    {
        public async Task<User> AuthenticateUser(string userName, string password)
        {
            using (var context = new ToDoServiceDBContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(d => d.Name == userName && d.Password == password);
                return user;
            }
        }

        public async Task<int> RegisterUser(User user)
        {
            using (var context = new ToDoServiceDBContext())
            {
                context.Users.Add(user);
                return await context.SaveChangesAsync();
            }
        }
    }
}
