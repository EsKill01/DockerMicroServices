using Lil.Custumers.Controllers;
using Lil.Custumers.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LilCustomers.Tests
{
    [TestClass]
    public class CutomersTest
    {
        [TestMethod]
        public void GetAsyncReturnsOk()
        {
            var customersProvider = new CustomersProvider();
            var customerController = new CustomersController(customersProvider);

            var result = customerController.GetAsync("1").Result;

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncReturnsNoFound()
        {
            var customersProvider = new CustomersProvider();
            var customerController = new CustomersController(customersProvider);

            var result = customerController.GetAsync("100").Result;

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
