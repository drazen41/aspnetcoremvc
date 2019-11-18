using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Infrastructure;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        // public IRepository Repository { get; set; } = new MemoryRepository();
        //public IRepository Repository { get; } = TypeBroker.Repository;
        private IRepository Repository;
        //private ProductTotalizer totalizer;
        public HomeController(IRepository repo)
        {
            Repository = repo;
            //totalizer = total;
        }
        public ViewResult Index([FromServices]ProductTotalizer totalizer)
        {
            IRepository rep = HttpContext.RequestServices.GetService<IRepository>();
            ViewBag.Totalizer = totalizer.Repository.ToString();
            ViewBag.HomeController = rep.ToString();
            
            return View(rep.Products);
        }

    }
}
