namespace Bookshelf.Tests.Services
{
    using System;
    using Bookshelf.Models;
    using Bookshelf.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class RentalServiceTests
    {
        private readonly Mock<BookshelfDbContext> bookshelfDbContext = new Mock<BookshelfDbContext>();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RentalService_BookshelfDbContextIsNull()
        {
            var given = new Prior
            {
                HasBookshelfDbContext = false
            };

            this.CreateRentalService(given);
        }

        private LibraryService CreateRentalService(Prior given)
        {
            return new LibraryService(
                given.HasBookshelfDbContext ? this.bookshelfDbContext.Object : null);
        }

        internal class Prior
        {
            public bool HasBookshelfDbContext { get; set; } = true;
        }
    }
}
