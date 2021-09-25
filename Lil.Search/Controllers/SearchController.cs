using Lil.Custumers.Interfaces;
using Lil.Search.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IProductsService productsService;
        private readonly ISalesService salesService;


        public SearchController(ICustomerService customerService, IProductsService productsService, ISalesService salesService)
        {
            this.customerService = customerService;
            this.productsService = productsService;
            this.salesService = salesService;
        }

        [HttpGet("customers/{costumerId}")]
        public async Task<IActionResult> SearchAsync(string costumerId)
        {
            if (string.IsNullOrEmpty(costumerId))
            {
                return this.BadRequest();
            }

            try
            {
                var customer = await this.customerService.GetAsync(costumerId);
                var sales = await this.salesService.GetAsync(costumerId);

                if (!sales.Any() || customer == null)
                {
                    return this.NotFound();
                }

                foreach (var sale in sales)
                {
                    foreach (var item in sale.Items)
                    {
                        var product = await this.productsService.GetAsync(item.ProductId);
                        item.Product = product;
                     
                    }
                }


                var response = new
                {
                    Customer = customer,
                    Sales = sales
                };

                return Ok(response);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
