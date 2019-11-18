using System;
using Xunit;
using Moq;
using DependencyInjection.Models;
using DependencyInjection.Controllers;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Infrastructure;

namespace SolutionTests
{
    public class DependencyInjectionTests
    {
        [Fact]
        public void ControllerTest()
        {
            var data = new[] { new Product { Name = "Test", Price = 100 } };
            var mock = new Mock<IRepository>();
            var total = new Mock<ProductTotalizer>();
            total.SetupGet(m => m.Total).Returns(123);
            mock.SetupGet(m => m.Products).Returns(data);
            //TypeBroker.SetTestObject(mock.Object);
            HomeController controller = new HomeController(mock.Object);
            ViewResult result = controller.Index(total.Object);
            Assert.Equal(data, result.ViewData.Model);
        }
    }
}
