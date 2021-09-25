using Lil.Custumers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Custumers.DAL
{
    public interface ICustomersProvider
    {
        Task<Customer> GetAsync(string id);
    }
}
