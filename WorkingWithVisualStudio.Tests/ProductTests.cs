using System;
using System.Collections.Generic;
using System.Text;
using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            var p = new Product { Name = "Test", Price = 100M };
            p.Name = "New Name";
            Assert.Equal("New Name", p.Name);
        }
    }
}
