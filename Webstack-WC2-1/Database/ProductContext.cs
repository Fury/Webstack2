using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webstack_WC2_1.Models;

namespace Webstack_WC2_1.Database
{
    public class ProductContext
    {
        public IEnumerable<Product> Products { get; private set; }

        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }

        public ProductContext()
        {
           var tempProducts = new List<Product>();
           tempProducts.Add(new Product("Pop", "Is een pop", "Speelgoed", 5.32M));
           tempProducts.Add(new Product("Wapen", "Is een wapen", "Speelgoed", 3.32M));
           tempProducts.Add(new Product("Koek", "Is een koek", "Voedsel", 0.32M));
            Products = tempProducts;
        }

        public IEnumerable<Product> GetProductsBySoort(string soort)
        {
            return (from p in Products where p.Soort == soort select p);
        }

        public IEnumerable<string> GetTypesEnumerable()
        {
            return Products.Select(x => x.Soort).Distinct();
        }
    }
}