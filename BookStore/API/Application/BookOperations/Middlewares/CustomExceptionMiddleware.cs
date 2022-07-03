using System.Diagnostics;
using System.Net;
using API.Services;
using Newtonsoft.Json;

namespace API.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate requestDelegate, ILoggerService loggerService)
        {
            _requestDelegate = requestDelegate;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string Message = "[Request] HTTP" + context.Request.Method + context.Request.Path;
                _loggerService.Write(Message);
                watch.Stop();

                await _requestDelegate(context);
                watch.Stop();

                Message = "[Request] HTTP" + context.Request.Method + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + "ms";
                _loggerService.Write(Message);

            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, ex, watch);
            }
        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "application.json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "[Error] HTTP" + context.Request.Method + context.Response.StatusCode + "ErrorMessage" + ex.Message + " in " + watch.Elapsed.TotalMilliseconds + " ms";
            _loggerService.Write(message);

            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);
            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}