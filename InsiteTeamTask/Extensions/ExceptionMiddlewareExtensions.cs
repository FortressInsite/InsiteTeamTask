using InsiteTeamTask.LoggerService;
using InsiteTeamTask.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace InsiteTeamTask.Extensions
{
    /// <summary>
    /// Configure useexeptionhandler middleware, try catch is simpler but wanted to achieve cleaner ctrlr
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureException(this IApplicationBuilder app, ILoggerMessage logger) 
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Something wrong here: {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Not found"
                        }.ToString());
                    }
                });
            });
        }
    }
}
