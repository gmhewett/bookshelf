namespace Bookshelf.Tests.Controllers
{
    using System;
    using Bookshelf.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RentalsControllerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RentalsController_BookServiceIsNull()
        {
            new RentalsController(null);
        }
    }
}
