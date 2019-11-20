using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Views.Infrastructure
{
    public class DebugDataView : IView
    {
        public string Path => string.Empty;

        public async Task RenderAsync(ViewContext context)
        {
            context.HttpContext.Response.ContentType = "text/plain";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--- Routing data ---");
            foreach (var kvp in context.RouteData.Values)
            {
                sb.AppendLine($"Key:{kvp.Key}, Value:{kvp.Value}");
            }
            sb.AppendLine("---View Data ---");
            foreach (var kvp in context.ViewData)
            {
                sb.AppendLine($"Key:{kvp.Key}, Value:{kvp.Value}");
            }
            await context.Writer.WriteAsync(sb.ToString());
        }

         
    }
}
