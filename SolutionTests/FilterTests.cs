using System;
using Xunit;
using Moq;
using System.Linq;
using Filters.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SolutionTests
{
    public class FilterTests
    {
        [Fact]
        public void TestHttpsFilter()
        {
            var httpRequest = new Mock<HttpRequest>();
            httpRequest.SetupSequence(m => m.IsHttps).Returns(true).Returns(false);
            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(m => m.Request).Returns(httpRequest.Object);
            var actionContext = new ActionContext(httpContext.Object, new Microsoft.AspNetCore.Routing.RouteData(), new ActionDescriptor());
            var authContext = new AuthorizationFilterContext(actionContext, Enumerable.Empty<IFilterMetadata>().ToList());
            HttpsOnlyAttribute filter = new HttpsOnlyAttribute();

            filter.OnAuthorization(authContext);
            Assert.Null(authContext.Result);
            filter.OnAuthorization(authContext);
            Assert.IsType<StatusCodeResult>(authContext.Result);
            Assert.Equal(StatusCodes.Status403Forbidden, (authContext.Result as StatusCodeResult).StatusCode);
        }
    }
}
