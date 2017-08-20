namespace Bookshelf.Tests.Services
{
    using System;
    using Bookshelf.Clients.GoogleBooksApi;
    using Bookshelf.Models;
    using Bookshelf.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class BookServiceTests
    {
        private readonly Mock<IGoogleBooksApiClient> googleBooksApiClient = new Mock<IGoogleBooksApiClient>();
        private readonly Mock<BookshelfDbContext> bookshelfDbContext = new Mock<BookshelfDbContext>();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BookService_GoogleBooksApiIsNull()
        {
            var given = new Prior
            {
                HasGoogleBooksApiClient = false
            };

            this.CreateBookService(given);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BookService_BookshelfDbContextIsNull()
        {
            var given = new Prior
            {
                HasBookshelfDbContext = false
            };

            this.CreateBookService(given);
        }

        private BookService CreateBookService(Prior given)
        {
            return new BookService(
                given.HasGoogleBooksApiClient ? this.googleBooksApiClient.Object : null,
                given.HasBookshelfDbContext ? this.bookshelfDbContext.Object : null);
        }

        internal class Prior
        {
            public bool HasGoogleBooksApiClient { get; set; } = true;

            public bool HasBookshelfDbContext { get; set; } = true;
        }
    }
}
