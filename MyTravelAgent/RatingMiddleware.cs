using DL;
using Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTravelAgent
{
    
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        MyTravelAgent2Context myTravelAgent;
        private readonly RequestDelegate _next;

        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext,MyTravelAgent2Context _myTravelAgent)
        {
            this.myTravelAgent = _myTravelAgent;

            Rating r = new Rating
            {
                Host = httpContext.Request.Host.ToString(),
                RecordDate = DateTime.Now,
                Method = httpContext.Request.Method,
                Path = httpContext.Request.Path.Value,
                UserAgent = httpContext.Request.Headers["User-Agent"].ToString(),
                Referer = httpContext.Request.Headers["Referer"]
            };
            await myTravelAgent.Ratings.AddAsync(r);
            await myTravelAgent.SaveChangesAsync();
            await _next(httpContext);

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
