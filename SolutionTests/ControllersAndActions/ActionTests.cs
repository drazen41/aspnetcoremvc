using System;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ControllersAndActions.Controllers;

namespace SolutionTests
{
    public class ActionTests
    {
        [Fact]
        public void ViewSelected()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.ReceiveForm("Adam", "London") as ViewResult;
            Assert.Equal("Result", result.ViewName);
        }
        [Fact]
        public void ModelObjectType()
        {
            ExampleController controller = new ExampleController();
            ViewResult result = controller.Index();
            //Assert.IsType<System.DateTime>(result.ViewData.Model);
            Assert.IsType<string>(result.ViewData["Message"]);
            Assert.Equal("Hello", result.ViewData["Message"]);
            Assert.IsType<System.DateTime>(result.ViewData["Date"]);
        }
        [Fact]
        public void Redirection()
        {
            ExampleController controller = new ExampleController();
            //RedirectResult result = controller.Redirect();
            //RedirectToRouteResult result = controller.Redirect();
            RedirectToActionResult result = controller.Redirect();
            //Assert.Equal("/Example/Index", result.Url);
            //Assert.True(result.Permanent);
            //Assert.False(result.Permanent);
            //Assert.Equal("Example", result.RouteValues["controller"]);
            //Assert.Equal("Index", result.RouteValues["action"]);
            //Assert.Equal("myID", result.RouteValues["ID"]);
            Assert.Equal("Home", result.ControllerName);
            Assert.Equal("Index", result.ActionName);
        }
        [Fact]
        public void JsonActionMethod()
        {
            HomeController controller = new HomeController();
            JsonResult result = controller.Index1();
            Assert.Equal(new[] { "Alice", "Bob", "Joe" }, result.Value);
        }
        [Fact]
        public void ForbiddenActionMethod()
        {
            ExampleController controller = new ExampleController();
            StatusCodeResult result = controller.Index4();
            Assert.Equal(403, result.StatusCode);
        }
    }
}
