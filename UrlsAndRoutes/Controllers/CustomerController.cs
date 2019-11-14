using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    [Route("app/[controller]/actions/[action]/{id:weekday?}")]
    public class CustomerController : Controller
    {
        //[Route("[controller]/MyAction")]
        public ViewResult Index() => View("Result", new Result { Controller = nameof(CustomerController), Action = nameof(Index) });
        public ViewResult List() => View("Result", new Result { Controller = nameof(CustomerController), Action = nameof(List) });
    }
}
