﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsingViewComponents.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsingViewComponents.Controllers
{
    [ViewComponent(Name ="ComboComponent")]
    public class CityController : Controller
    {
        private ICityRepository repository;
        public CityController(ICityRepository repo)
        {
            repository = repo;
        }
        public ViewResult Create() => View();
        [HttpPost]
        public IActionResult Create(City newCity)
        {
            repository.AddCity(newCity);
            return RedirectToAction("Index", "Home");
        }
        public IViewComponentResult Invoke() => new ViewViewComponentResult()
        {
            ViewData = new ViewDataDictionary<IEnumerable<City>>(ViewData,
        repository.Cities)
        };
    }
}
