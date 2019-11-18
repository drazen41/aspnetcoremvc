using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filters.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    //[Profile]
    //[ViewResultDetails]
    //[RangeException]
    [TypeFilter(typeof(DiagnosticsFilter))]
    //[TypeFilter(typeof(TimeFilter))]
    [ServiceFilter(typeof(TimeFilter))]
    public class HomeController : Controller
    {
        public ViewResult Index() => View("Message", "This is the Index action on the Home controller");

        public IActionResult SecondAction()
        {
            //if (!Request.IsHttps)
            //{
            //    return new StatusCodeResult(StatusCodes.Status403Forbidden);
            //}
            //else
            //{
            //    return View("Message",
            //    "This is the SecondAction action on the Home controller");
            //}
            return View("Message",
                "This is the SecondAction action on the Home controller");
        }
        public ViewResult GenerateException(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            else if (id > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            else
            {
                return View("Message", $"The value is {id}");
            }
        }
    }
    
}
