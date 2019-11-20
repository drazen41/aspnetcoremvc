using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsingViewComponents.Models;

namespace UsingViewComponents.Components
{
    public class CitySummary : ViewComponent 
    {
        private ICityRepository repository;
        public CitySummary(ICityRepository repo)
        {
            repository = repo;
            
        }
        public IViewComponentResult Invoke(bool showList)
        {
            if (showList)
                return View("CityList", repository.Cities);
            else
            {
                //string target = RouteData.Values["id"] as string;
                //var cities = repository.Cities.Where(c => target == null || string.Compare(c.Country, target, true) == 0);
                var cities = repository.Cities;
                return View(new CityViewModel { Cities = cities.Count(), Population = cities.Sum(c => c.Population) });
            }
            //return $"{repository.Cities.Count()} cities," + $"{repository.Cities.Sum(c => c.Population)} people";
            
        }
    }
}
