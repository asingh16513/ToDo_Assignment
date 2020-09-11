using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Helper
{
    public class InitializeDbService
    {
        public static IServiceCollection AddDbServiceConfigurations(IServiceCollection configuration)
        {
            ToDoServiceDBContext serviceDBContext  = new ToDoServiceDBContext();
            serviceDBContext.Database.Migrate();
            return configuration;
        }
    }
}
