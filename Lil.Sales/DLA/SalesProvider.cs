using Lil.Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Sales.DLA
{
    public class SalesProvider : ISalesProvider
    {
        private readonly List<Order> repo = new List<Order>();

        public SalesProvider()
        {
            for (int i = 0; i < 5; i++)
            {
                repo.Add(new Order()
                {
                    Id = i.ToString(),
                    CustomerId = (i + 1).ToString(),
                    OrderDate = DateTime.Now.AddMonths(-i),
                    Total = i * 5 * (i + i * 3),
                    Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                             Id = i+1,
                             OrderId = $"000{i+1}",
                             Price = i*5*(i+i*1),
                             ProductId = (i*5).ToString(),
                             Quantity = i+i*2
                        }
                    }
                });
            }
        }

        public Task<ICollection<Order>> GetAsync(string customerId)
        {
            var orders = repo.Where(o => o.CustomerId == customerId).ToList();

            return Task.FromResult((ICollection<Order>)orders);
        }
    }
}
