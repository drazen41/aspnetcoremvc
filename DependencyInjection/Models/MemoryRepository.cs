﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
    public class MemoryRepository : IRepository
    {
        //private Dictionary<string, Product> products;
        private IModelStorage storage;
        private string guid = System.Guid.NewGuid().ToString();
        public MemoryRepository(IModelStorage modelStore)
        {
            storage = modelStore;
            //products = new Dictionary<string, Product>();
            new List<Product>
            {
                new Product { Name = "Kayak", Price = 275M},
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M }
            }.ForEach(p => AddProduct(p));
        }
        public Product this[string name] => storage[name];

        public IEnumerable<Product> Products => storage.Items;

        public void AddProduct(Product product)
        {
            //products[product.Name] = product;
            storage[product.Name] = product;
        }

        public void DeleteProduct(Product product)
        {
            //products.Remove(product.Name);
            storage.RemoveItem(product.Name);
        }
        public override string ToString()
        {
            return guid;
        }
    }
}
