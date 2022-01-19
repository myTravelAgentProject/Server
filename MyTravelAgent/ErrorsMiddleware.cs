﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTravelAgent
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorsMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<ErrorsMiddleware> logger)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError("Error from My MiddleWAre : "+ex.Message +"stack Trace is:"+ ex.StackTrace);
                httpContext.Response.StatusCode = 500;
            }
           
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorsMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorsMiddleware>();
        }
    }
}
