namespace Bookshelf.Tests.Clients
{
    using System;
    using Bookshelf.Clients.GoogleBooksApi;
    using Bookshelf.Config;
    using Bookshelf.Loggers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class GoogleBooksApiClientTests
    {
        private readonly Mock<IBookshelfConfig> config = new Mock<IBookshelfConfig>();
        private readonly Mock<IBookshelfLogger> logger = new Mock<IBookshelfLogger>();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GoogleBooksApiClient_BookshelfConfigIsNull()
        {
            var given = new Prior
            {
                HasBookshelfConfig = false
            };

            this.CreateClient(given);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GoogleBooksApiClient_BookshelfLoggerIsNull()
        {
            var given = new Prior
            {
                HasBookshelfLogger = false
            };

            this.CreateClient(given);
        }

        private GoogleBooksApiClient CreateClient(Prior given)
        {
            return new GoogleBooksApiClient(
                given.HasBookshelfConfig ? this.config.Object : null,
                given.HasBookshelfLogger ? this.logger.Object : null);
        }

        internal class Prior
        {
            public bool HasBookshelfConfig = true;

            public bool HasBookshelfLogger = true;
        }
    }
}
