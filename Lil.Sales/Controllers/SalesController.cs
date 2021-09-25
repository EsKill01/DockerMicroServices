using Lil.Sales.DLA;
using Lil.Sales.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Sales.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {

        private readonly ISalesProvider salesProvider;
        public SalesController(ISalesProvider salesProvider)
        {
            this.salesProvider = salesProvider;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            var res = salesProvider.GetAsync(customerId).Result;

            if (res != null && res.Any())
            {
                return Ok(res);
            }

            return NotFound();

        }
    }
}
