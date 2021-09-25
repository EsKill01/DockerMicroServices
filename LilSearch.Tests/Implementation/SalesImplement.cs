using Lil.Sales.DLA;
using Lil.Sales.Models;
using Lil.Search.Interfaces;
using Lil.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LilSearch.Tests.Implementation
{
    public class SalesImplement : ISalesService
    {
        private readonly List<Lil.Search.Models.Order> repo = new List<Lil.Search.Models.Order>();

        public SalesImplement()
        {
            for (int i = 0; i < 5; i++)
            {
                repo.Add(new Lil.Search.Models.Order()
                {
                    Id = i.ToString(),
                    CustomerId = (i + 1).ToString(),
                    OrderDate = DateTime.Now.AddMonths(-i),
                    Total = i * 5 * (i + i * 3),
                    Items = new List<Lil.Search.Models.OrderItem>()
                    {
                        new Lil.Search.Models.OrderItem()
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

        public async Task<ICollection<Lil.Search.Models.Order>> GetAsync(string customerId)
        {

            var orders = repo.Where(o => o.CustomerId == customerId).ToList();

            return await Task.FromResult((ICollection<Lil.Search.Models.Order>)orders);
        }
    }
}
