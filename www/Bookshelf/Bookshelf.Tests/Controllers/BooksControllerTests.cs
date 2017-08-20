namespace Bookshelf.Tests.Controllers
{
    using System;
    using Bookshelf.Controllers;
    using Bookshelf.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class BooksControllerTests
    {
        private readonly Mock<IBookService> bookService = new Mock<IBookService>();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BooksController_BookServiceIsNull()
        {
            var given = new Prior
            {
                HasBookService = false
            };

            this.CreateBooksController(given);
        }

        private BooksController CreateBooksController(Prior given)
        {
            return new BooksController(
                given.HasBookService ? this.bookService.Object : null);
        }

        internal class Prior
        {
            public bool HasBookService { get; set; } = true;
        }
    }
}
