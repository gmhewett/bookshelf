namespace Bookshelf.Tests.Controllers
{
    using System;
    using Bookshelf.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BooksControllerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BooksController_BookServiceIsNull()
        {
            new BooksController(null);
        }
    }
}
