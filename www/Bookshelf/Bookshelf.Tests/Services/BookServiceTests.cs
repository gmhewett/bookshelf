namespace Bookshelf.Tests.Services
{
    using System;
    using Bookshelf.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BookServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BookService_DbContextIsNull()
        {
            new BookService(null);
        }
    }
}
