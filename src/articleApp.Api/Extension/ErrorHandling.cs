using System;
using articleApp.Api.Infrastructure;
using Microsoft.AspNetCore.Builder;

namespace articleApp.Api.Extension
{
    public static class ErrorHandling
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}