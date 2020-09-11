using System;
using System.Net;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;  

namespace ToDoService.API.Middleware
{
    public class ErrorHandling
    {
        private readonly RequestDelegate _next;

        public ErrorHandling(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<ErrorHandling> logger)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, logger);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger logger)
		{
			var code = HttpStatusCode.InternalServerError; // 500 if unexpected

			//if (ex is appEx.NotFoundException) code = HttpStatusCode.NotFound; 

			string result = string.Empty;
			if (code != HttpStatusCode.InternalServerError)
				result = JsonConvert.SerializeObject(new { error = ex.Message });
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)code;

			logger.LogError(ex.ToString());

			return context.Response.WriteAsync(result);
		}
	}
}
