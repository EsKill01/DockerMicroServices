using Lil.Custumers.Interfaces;
using Lil.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LilSearch.Tests.Implementation
{
    public class ProductsImplement : IProductsService
    {
        private List<Product> repo = new List<Product>();

        public ProductsImplement()
        {
            for (int i = 0; i < 100; i++)
            {
                repo.Add(new Product()
                {
                    Id = i.ToString(),
                    Name = $"Producto {i + 1}",
                    Price = (double)i * 3.14
                });
            }
        }

        public Task<Product> GetAsync(string id)
        {
            var product = repo.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }
    }
}
