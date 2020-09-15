using Application.Helper;
using Application.Interface;
using Application.Label.Queries.GetLabels;
using Application.QueryTypes;
using Domain.GraphQlModels;
using HotChocolate;
using HotChocolate.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.IO;
using ToDoService.API.Middleware;
using ToDoService.Helpers;
using ToDoService.Middleware;

namespace ToDoService
{
    /// <summary>
    /// startup class 
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services
                .AddDataLoaderRegistry()
                .AddGraphQL(s => SchemaBuilder.New()
                .AddServices(s)
                .AddType<LabelType>()
                .AddQueryType<LabelQueryType>()
                .Create()); 
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });
            services.AddMvc(p => p.RespectBrowserAcceptHeader = true).AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.PropertyNamingPolicy = null;
                    o.JsonSerializerOptions.DictionaryKeyPolicy = null;
                })
            .AddXmlSerializerFormatters();
            services.AddMediatR(typeof(GetLabelListHandler).Assembly);

            services.AddSingleton<IInstanceDB, GetInstance>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IPatchToDo, PatchHelper>();
            services.AddScoped<IDTO, DTOHelper>();

            ConfigurationManager.LoadConfigurationSettings(services, Configuration);
            services.AddSingleton<IPostConfigureOptions<JwtBearerOptions>, ConfigureJwtBearerOptions>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddSingleton<IMD5Hash, MD5HashHelper>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer();

            services.AddSwaggerGen(s =>
            {

                s.SwaggerDoc("v2", new OpenApiInfo { Title = "To Do Service API", Version = "v2" });
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                  });
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            } 
            app.UseGraphQL();
            app.UsePlayground();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseMiddleware(typeof(ErrorHandling));
            app.UseMiddleware(typeof(RequestLogging));
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v2/swagger.json", "ToDoService API V2");
            });

        }
    }
}
