using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using ControllersAndActions.Infrastructure;

namespace ControllersAndActions.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View("SimpleForm");
        public IActionResult ReceiveForm(string name, string city)
        {
            //var name = Request.Form["name"];
            //var city = Request.Form["city"];
            //return View("Result", $"{name} lives in {city}");

            //Response.StatusCode = 200;
            //Response.ContentType = "text/html";
            //byte[] content = Encoding.ASCII.GetBytes($"<html><body>{name} lives in {city} grad.</body></html>");
            //Response.Body.WriteAsync(content, 0, content.Length);

            //return new CustomHtmlResult { Content = $"{name} lives in {city}" };

            //return View("Result", $"{name} lives in {city}");
            TempData["name"] = name;
            TempData["city"] = city;
            return RedirectToAction(nameof(Data));
        }
        public ViewResult Data()
        {
            string name = TempData["name"] as string;
            string city = TempData["city"] as string;
            return View("Result", $"{name} lives in {city}");
        }
        public JsonResult Index1() => Json(new[] { "Alice", "Bob", "Joe" });
    }
}
