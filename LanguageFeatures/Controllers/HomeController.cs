using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        bool FilterByPrice(Product p)
        {
            return (p?.Price ?? 0) >= 20;
        }
        public async Task<ViewResult> Index()
        {
            //return View(new string[] { "C#", "Language", "Features" });
            List<string> results = new List<string>();
            foreach (Product p in Product.GetProducts())
            {
                string name = p?.Name ?? "<No Name>";
                decimal? price = p?.Price ?? 0;
                string relatedName = p?.Related?.Name ?? "<None>";
                //results.Add(string.Format("Name: {0}, Price:{1}, Related:{2} ", name, price,relatedName));
                results.Add($"Name:{name}, Price:{price}, Related:{relatedName}");
            }
            Dictionary<string, Product> products = new Dictionary<string, Product>
            {
                ["Kayak"] = new Product { Name = "Kayak", Price = 275M },
                ["Lifejacket"] = new Product { Name = "Lifejacket", Price = 48.95M }
            };
            //return View(results);
            //return View("Index", products.Keys);
            object[] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };
            decimal total = 0;
            //for (int i = 0; i < data.Length; i++)
            //{
            //    if(data[i] is decimal d)
            //    {
            //        total += d;
            //    }
            //}
            for (int i = 0; i < data.Length; i++)
            {
                switch (data[i])
                {
                    case decimal d:
                        total += d;
                        break;
                    case int intValue when intValue > 50:
                        total += intValue;
                        break;
                    default:
                        break;
                }
            }
            ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            Product[] prodArray =
            {
                new Product { Name = "Kayak",Price = 275M},
                new Product { Name = "Lifejacket", Price=48.95M},
                new Product { Name = "Soccer ball", Price= 19.50M},
                new Product { Name = "Corner flag", Price = 34.95M}
            };

            decimal cartTotal = cart.TotalPrices();
            decimal arrayTotal = prodArray.FilterByPrice(20).TotalPrices();
            //return View("Index", new string[] { $"Cart total:{cartTotal:C2}", $"Array total:{arrayTotal:C2}" });
            Func<Product, bool> nameFilter = delegate (Product prod)
            {
                return prod?.Name[0] == 'S';
            };
            //decimal nameFilterTotal = prodArray.Filter(nameFilter).TotalPrices();
            //decimal priceFilterTotal = prodArray.Filter(FilterByPrice).TotalPrices();

            decimal priceFilterTotal = prodArray.Filter(p => (p?.Price ?? 0) >= 20).TotalPrices();
            decimal nameFilterTotal = prodArray.Filter(p => (p?.Name[0] == 'S')).TotalPrices();

            //return View("Index", new string[] { $"Price total:{priceFilterTotal:C2}", $"Name total:{nameFilterTotal}" });
            //return View(Product.GetProducts().Select(p => p?.Name));

            long? length = await MyAsyncMethods.GetPageLength1();
            string content = await MyAsyncMethods.GetPageContent();
            return View(new string[] { $"Length:{length}", $"Content:{content}" });

            
        }
    }
}