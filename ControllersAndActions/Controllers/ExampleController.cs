using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        //public ViewResult Index() => View(DateTime.Now);
        public ViewResult Index()
        {
            ViewBag.Message = "Hello";
            ViewBag.Date = DateTime.Now;
            return View();
        }
        public RedirectToActionResult Redirect() =>
            //RedirectPermanent("/Example/Index");
            //RedirectToRoute(new { controller = "Example", action = "Index", ID = "myID" });
            RedirectToAction(nameof(Index),"Home" );
        public ContentResult Index1()
            => Content("[\"Alice\",\"Bob\",\"Joe\"]", "application/json");
        public ObjectResult Index2()
            => Ok(new string[] { "Alice", "Bob", "Joe" });
        public VirtualFileResult Index3()
            => File("/lib/bootstrap/css/bootstrap.css", "text/css");
        public StatusCodeResult Index4()
            => StatusCode(StatusCodes.Status403Forbidden);
    }
}
