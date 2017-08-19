namespace Bookshelf.Tests.Services
{
    using System;
    using Bookshelf.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RentalServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RentalService_DbContextIsNull()
        {
            new RentalService(null);
        }
    }
}
