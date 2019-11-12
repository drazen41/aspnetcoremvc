using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ConfiguringApps.Infrastructure
{
    public class ShortCicuitingMiddleware
    {
        private RequestDelegate nextDelegate;
        public ShortCicuitingMiddleware(RequestDelegate del)
        {
            nextDelegate = del;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            //if (httpContext.Request.Headers["User-Agent"].Any(h => h.ToLower().Contains("edge")))
            //{
            //    httpContext.Response.StatusCode = 403;
            //} else
            //{
            //    await nextDelegate.Invoke(httpContext);
            //}
            if (httpContext.Items["EdgeBrowser"] as bool? == true)
            {
                httpContext.Response.StatusCode = 403;
            } else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}
