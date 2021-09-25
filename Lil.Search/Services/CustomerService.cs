using Lil.Custumers.Interfaces;
using Lil.Search.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lil.Custumers.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IHttpClientFactory httpClientFactory;
        public CustomerService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<Customer> GetAsync(string id)
        {
            var client = httpClientFactory.CreateClient("customerService");

            var respone = await client.GetAsync($"api/customers/{id}");

            if (respone.IsSuccessStatusCode)
            {
                var content = await respone.Content.ReadAsStringAsync();

                var customer = JsonConvert.DeserializeObject<Customer>(content);

                return customer;
            }

            return null;

        }
    }
}
