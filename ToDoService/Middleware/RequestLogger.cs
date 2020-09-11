using System;
using System.IO;
using System.Text;
using System.Threading.Tasks; 
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ToDoService.Middleware
{
    public class RequestLogging
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public RequestLogging(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLogging>();
        }

        public async Task Invoke(HttpContext httpContext, IOptions<ApplicationSetting> applicationSettingAccessor)
        {
            httpContext.Request.EnableBuffering();
            await _next(httpContext); 

            _logger.LogInformation(
                   "Request {method} {url} => {statusCode}",
                   httpContext.Request?.Method,
                   httpContext.Request?.Path.Value,
                   httpContext.Response?.StatusCode);

        }
    }
}

