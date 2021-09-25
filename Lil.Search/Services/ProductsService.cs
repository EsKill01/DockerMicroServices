using Lil.Custumers.Interfaces;
using Lil.Products.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lil.Custumers.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ProductsService (IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }


        public async Task<Product> GetAsync(string id)
        {
            var client = httpClientFactory.CreateClient("productService");

            var response = await client.GetAsync($"api/Products/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var product = JsonConvert.DeserializeObject<Product>(content);

                return product;
            }

            return null;
        }
    }
}
