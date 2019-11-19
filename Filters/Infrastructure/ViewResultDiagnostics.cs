using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure
{
    public class ViewResultDiagnostics : IActionFilter
    {
        private IFilterDiagnnostics diagnostics;
        public ViewResultDiagnostics(IFilterDiagnnostics diags)
        {
            diagnostics = diags;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            ViewResult vr;
            if ((vr=context.Result as ViewResult) != null)
            {
                diagnostics.AddMessage($"View name: {vr.ViewName}");
                diagnostics.AddMessage($"Model type: {vr.ViewData.Model.GetType().Name}");
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
             
        }
    }
}
