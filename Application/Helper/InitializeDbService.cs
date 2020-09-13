using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Helper
{
    public class InitializeDbService
    {
        public static IServiceCollection AddDbServiceConfigurations(IServiceCollection configuration)
        {
            ToDoServiceDBContext serviceDBContext = new ToDoServiceDBContext();
            serviceDBContext.Database.Migrate();
            return configuration;
        }
    }
}
