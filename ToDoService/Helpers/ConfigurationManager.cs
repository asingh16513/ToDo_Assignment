using Application.Helper;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoService.Helpers
{
    public static class ConfigurationManager
    {
        public static void LoadConfigurationSettings(IServiceCollection services, IConfiguration configuration)
        {
            /*
             One advantage to using IOptions<T> is that it can detect changes to the configuration source and
             reload configuration as the application is running.
            */
            services.AddOptions();
            //Configure Option using Extensions method
            services.Configure<ApplicationSetting>(configuration.GetSection("ApplicationSettings"));
            services.Configure<ConnectionSettings>(configuration.GetSection("ConnectionStrings"));
            services.AddSingleton(configuration);
            InitializeDbService.AddDbServiceConfigurations(services);
        }
    }
}
