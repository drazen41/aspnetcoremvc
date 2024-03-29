﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace Filters.Infrastructure
{
    public class MessageAttribute : ResultFilterAttribute 
    {
        private string message;
        public MessageAttribute(string msg)
        {
            message = msg;
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            WriteMessage(context, $"<div>Before Result:{message}</div>");
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            WriteMessage(context, $"<div>After Result:{message}</div>");
        }
        private void WriteMessage(FilterContext context, string v)
        {
            byte[] bytes = Encoding.ASCII.GetBytes($"<div>{v}</div>");
            context.HttpContext.Response.Body.Write(bytes, 0, bytes.Length);
        }
    }
}
