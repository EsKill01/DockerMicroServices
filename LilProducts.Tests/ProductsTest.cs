using Lil.Products.Controllers;
using Lil.Products.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LilProducts.Tests
{
    [TestClass]
    public class ProductsTest
    {
        [TestMethod]
        public void GetAsyncOk()
        {
            var productProvider = new ProductsProvider();
            var productsController = new ProductsController(productProvider);

            var result = productsController.GetAsync("1").Result;

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncNotFound()
        {
            var productProvider = new ProductsProvider();
            var productsController = new ProductsController(productProvider);

            var result = productsController.GetAsync("5485").Result;

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
