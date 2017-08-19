namespace Bookshelf.Tests.Controllers
{
    using System;
    using Bookshelf.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LibrariesControllerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LibrariesController_BookServiceIsNull()
        {
            new LibrariesController(null);
        }
    }
}
