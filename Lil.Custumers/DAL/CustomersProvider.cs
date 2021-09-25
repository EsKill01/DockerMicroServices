using Lil.Custumers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Custumers.DAL
{
    public class CustomersProvider : ICustomersProvider
    {
        private readonly List<Customer> repo = new List<Customer>();

        public CustomersProvider()
        {
            for (int i = 4 - 1; i >= 0; i--)
            {
                repo.Add(new Customer()
                {
                    Id = (i + 1).ToString(),
                    Name = $"Esteban{i + 1}",
                    City = $"Calle {(i * 3 + 1).ToString()} "
                });
            }
        }

        public Task<Customer> GetAsync(string id)
        {
            var customer = repo.FirstOrDefault(c => c.Id == id);

            return Task.FromResult(customer);
        }
    }
}
