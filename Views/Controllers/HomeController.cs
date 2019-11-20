using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult IndexOld()
        {
            ViewBag.Message = "Hello, World";
            ViewBag.Time = DateTime.Now.ToString("HH:mm:ss");
            return View("DebugData");
        }
        public ViewResult Index() => View(new string[] { "Apple", "Orange", "Pear" });
        public ViewResult List() => View();
    }
}
