using Lil.Custumers.Interfaces;
using Lil.Custumers.Services;
using Lil.Search.Controllers;
using LilSearch.Tests.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace LilSearch.Tests
{
    [TestClass]
    public class SearchTests
    {
        [TestMethod]
        public void GetAsyncOk()
        {
            var customerImplementation = new CustomerImplement();
            var productImplementation = new ProductsImplement();
            var salesImplementation = new SalesImplement();

            var seatchController = new SearchController(customerImplementation, productImplementation, salesImplementation);

            var result = seatchController.SearchAsync("1").Result;

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncNotFound()
        {
            var customerImplementation = new CustomerImplement();
            var productImplementation = new ProductsImplement();
            var salesImplementation = new SalesImplement();

            var seatchController = new SearchController(customerImplementation, productImplementation, salesImplementation);

            var result = seatchController.SearchAsync("-1").Result;

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
