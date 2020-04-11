using System;
using System.Threading.Tasks;
using articleApp.Business.Extensions;
using Microsoft.AspNetCore.Http;

namespace articleApp.Api.Infrastructure
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception exception)
            {
                await HandleException(context, exception);
            }
        }

        private async Task HandleException(HttpContext context, Exception exception)
        {

            context.Response.ContentType = "application/json";
            if (exception is NotificationException notification)
            {
                context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(notification.Message));
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject("Error"));
            }
        }
    }
}