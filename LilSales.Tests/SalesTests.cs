using Lil.Sales.Controllers;
using Lil.Sales.DLA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LilSales.Tests
{
    [TestClass]
    public class SalesTests
    {
        [TestMethod]
        public void GetAsyncOk()
        {
            SalesProvider salesProvider = new SalesProvider();
            var salesController = new SalesController(salesProvider);

            var result = salesController.GetAsync("1").Result;

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncNotFound()
        {
            SalesProvider salesProvider = new SalesProvider();
            var salesController = new SalesController(salesProvider);

            var result = salesController.GetAsync("222321").Result;

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
