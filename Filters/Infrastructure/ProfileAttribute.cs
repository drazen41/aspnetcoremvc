using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure
{
    public class ProfileAttribute : ActionFilterAttribute
    {
        private Stopwatch timer;
        private double actionTime;
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    timer = Stopwatch.StartNew();
        //}
        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    timer.Stop();
        //    string result = "<div>Elapsed time: " + $"{timer.Elapsed.TotalMilliseconds} ms</div>";
        //    byte[] bajts = Encoding.ASCII.GetBytes(result);
        //    context.HttpContext.Response.Body.Write(bajts, 0, bajts.Length);
        //}
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            timer = Stopwatch.StartNew();
            await next();
            actionTime = timer.Elapsed.TotalMilliseconds;
            //timer.Stop();
            //string result = "<div>Elapsed time: "+ $"{timer.Elapsed.TotalMilliseconds} ms</div>";
            //byte[] bytes = Encoding.ASCII.GetBytes(result);
            //await context.HttpContext.Response.Body.WriteAsync(bytes,0, bytes.Length);
        }
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();
            timer.Stop();
            string result = "<div>Action time: " + $"{actionTime} ms</div><div>Total time: " + $"{timer.Elapsed.TotalMilliseconds} ms</div>";
            byte[] bytes = Encoding.ASCII.GetBytes(result);
            await context.HttpContext.Response.Body.WriteAsync(bytes,0, bytes.Length);
        }
    }
}
