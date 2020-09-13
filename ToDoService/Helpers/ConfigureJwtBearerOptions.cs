using Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ToDoService.Helpers
{
    public class ConfigureJwtBearerOptions : IPostConfigureOptions<JwtBearerOptions>
    {
        private readonly IOptions<ApplicationSetting> _applicationSetting;

        public ConfigureJwtBearerOptions(IOptions<ApplicationSetting> applicationSetting)
        {
            _applicationSetting = applicationSetting ?? throw new System.ArgumentNullException(nameof(applicationSetting));
        }

        public void PostConfigure(string name, JwtBearerOptions options)
        {
            var applicationSetting = _applicationSetting.Value;
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(applicationSetting.AuthenticationTokenSecret)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }
    }
}
