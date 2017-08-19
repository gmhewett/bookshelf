namespace Bookshelf.Tests.Services
{
    using System;
    using Bookshelf.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LibraryServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LibraryService_DbContextIsNull()
        {
            new LibraryService(null);
        }
    }
}
