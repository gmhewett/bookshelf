namespace Bookshelf.Tests.Services
{
    using System;
    using Bookshelf.Models;
    using Bookshelf.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class LibraryServiceTests
    {
        private readonly Mock<BookshelfDbContext> bookshelfDbContext = new Mock<BookshelfDbContext>();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LibraryService_BookshelfDbContextIsNull()
        {
            var given = new Prior
            {
                HasBookshelfDbContext = false
            };

            this.CreateLibraryService(given);
        }

        private LibraryService CreateLibraryService(Prior given)
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
