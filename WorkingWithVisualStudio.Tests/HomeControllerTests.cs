using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;
using Moq;


namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {
        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products => new Product[]
            {
                new Product { Name="P1", Price = 20M},
                new Product { Name="P2", Price = 48.95M},
                new Product { Name="P3", Price = 19.50M},
                new Product { Name="P4", Price = 34.95M},
            };
            public void AddProduct(Product p)
            {
                throw new NotImplementedException();
            }
        }
        class ModelCompleteFakeRepository2 : IRepository
        {
            public IEnumerable<Product> Products { get; set; }
            public void AddProduct(Product p)
            {
                throw new NotImplementedException();
            }
        }
        [Fact]
        public void IndexActionModelIsComplete()
        {
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepository();
            var model = (IEnumerable<Product>)(controller.Index() as ViewResult)?.ViewData.Model;
            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
        [Theory]
        [InlineData(275,48.95,19.50,24.95)]
        [InlineData(5,48.95,19.50,24.95)]
        public void IndexActionModelIsComplete2(decimal price1, decimal price2, decimal price3, decimal price4)
        {
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepository2
            {
                Products = new Product[]
            {
                new Product { Name = "P1", Price = price1},
                new Product { Name = "P2", Price = price2},
                new Product { Name = "P3", Price = price3},
                new Product { Name = "P4", Price = price4}
            }
            };
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete3(Product[]products)
        {
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepository2
            {
                Products = products
            };
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete4(Product[] products)
        {
            var controller = new HomeController();
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            controller.Repository = mock.Object;

            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}
