namespace Bookshelf.Tests.Controllers
{
    using System;
    using Bookshelf.Controllers;
    using Bookshelf.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class LibrariesControllerTests
    {
        private readonly Mock<ILibraryService> libraryService = new Mock<ILibraryService>();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LibrariesController_LibraryServiceIsNull()
        {
            var given = new Prior
            {
                HasLibraryService = false
            };

            this.CreateLibrariesController(given);
        }

        private LibrariesController CreateLibrariesController(Prior given)
        {
            return new LibrariesController(
                given.HasLibraryService ? this.libraryService.Object : null);
        }

        internal class Prior
        {
            public bool HasLibraryService { get; set; } = true;
        }
    }
}
