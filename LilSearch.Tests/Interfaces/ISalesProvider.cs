using Lil.Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Sales.DLA
{
    public interface ISalesProvider
    {
        Task<ICollection<Order>> GetAsync(string customerId);
    }
}
