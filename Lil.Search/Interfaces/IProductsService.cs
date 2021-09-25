using Lil.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Custumers.Interfaces
{
    public interface IProductsService
    {
        Task<Product> GetAsync(string id);
    }
}
