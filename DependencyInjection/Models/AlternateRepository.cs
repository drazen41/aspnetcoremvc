﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
    public class AlternateRepository : IRepository
    {
        private Dictionary<string, Product> products;
        public AlternateRepository()
        {
            products = new Dictionary<string, Product>();
            new List<Product> {
                new Product { Name = "Corner Flags", Price = 34.95M },
                new Product { Name = "Stadium", Price = 79500M }
                }.ForEach(p => AddProduct(p));
        }
        public Product this[string name] => products[name];

        public IEnumerable<Product> Products => products.Values;

        public void AddProduct(Product product)
        {
            products[product.Name] = product;
        }

        public void DeleteProduct(Product product)
        {
            products.Remove(product.Name);
        }
    }
}
